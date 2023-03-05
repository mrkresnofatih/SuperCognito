using DesertCamel.BaseMicroservices.SuperCognito.Models;
using DesertCamel.BaseMicroservices.SuperCognito.Models.AuthService;
using DesertCamel.BaseMicroservices.SuperCognito.Models.CognitoService;
using DesertCamel.BaseMicroservices.SuperCognito.Models.UserPoolService;
using DesertCamel.BaseMicroservices.SuperCognito.Models.UserService;
using DesertCamel.BaseMicroservices.SuperCognito.Services.CognitoService;
using DesertCamel.BaseMicroservices.SuperCognito.Services.UserPoolService;
using DesertCamel.BaseMicroservices.SuperCognito.Services.UserService;
using DesertCamel.BaseMicroservices.SuperCognito.Utilities;
using Microsoft.Extensions.Options;

namespace DesertCamel.BaseMicroservices.SuperCognito.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly SuperCognitoApi _superCognitoApi;
        private readonly IUserService _userService;
        private readonly IUserPoolService _userPoolService;
        private readonly ICognitoService _cognitoService;
        private readonly ILogger<AuthService> _logger;

        public AuthService(
            IOptions<SuperCognitoApi> superCognitoApi,
            IUserService userService,
            IUserPoolService userPoolService,
            ICognitoService cognitoService,
            ILogger<AuthService> logger)
        {
            _superCognitoApi = superCognitoApi.Value;
            _userService = userService;
            _userPoolService = userPoolService;
            _cognitoService = cognitoService;
            _logger = logger;
        }

        public FuncResponse<AuthLoginResponseModel> Login(AuthLoginRequestModel loginRequest)
        {
            _logger.LogInformation($"Start Login w. data : {loginRequest.ToJson()}");
            var userPoolGetResult = _userPoolService.GetUserPool(new UserPoolGetRequestModel
            {
                UserPoolId = loginRequest.UserPoolId
            }).Result;
            if (userPoolGetResult.IsError())
            {
                _logger.LogError(userPoolGetResult.ErrorMessage);
                return new FuncResponse<AuthLoginResponseModel>
                {
                    ErrorMessage = "failed to get user pool"
                };
            }

            var userPoolData = userPoolGetResult.Data;
            var cognitoTokenResult = _cognitoService.ExchangeToken(new CognitoExchangeTokenRequestModel
            {
                ClientId = userPoolData.ClientId,
                ClientSecret = userPoolData.ClientSecret,
                AuthorizationCode = loginRequest.AuthorizationCode,
                ExchangeTokenUrl = userPoolData.ExchangeTokenUrl,
                RedirectUri = _superCognitoApi.UIBaseUrl + String.Format(_superCognitoApi.UIUriLoginRedirect, loginRequest.UserPoolId)
            });
            if (cognitoTokenResult.IsError())
            {
                _logger.LogError(cognitoTokenResult.ErrorMessage);
                return new FuncResponse<AuthLoginResponseModel>
                {
                    ErrorMessage = "failed to get token from aws cognito"
                };
            }

            var accessToken = cognitoTokenResult.Data.AccessToken;

            _logger.LogInformation("attempting to fetch userinfo endpoint");
            var userInfoResult = _cognitoService.UserInfo(new CognitoUserInfoRequestModel
            {
                UserInfoUrl = userPoolData.UserInfoUrl,
                AccessToken = accessToken
            });
            if (userInfoResult.IsError())
            {
                _logger.LogError(userInfoResult.ErrorMessage);
                return new FuncResponse<AuthLoginResponseModel>
                {
                    ErrorMessage = "failed to find userinfo using token"
                };
            }

            var userInfoData = userInfoResult.Data;
            var dictionaryOfUserInfo = userInfoData.ToStringDictionary();
            _logger.LogInformation($"obtained user info data: {userInfoData.ToJson()}");

            var userGetResult = _userService.Get(new UserGetRequestModel
            {
                PrincipalName = dictionaryOfUserInfo.GetValueOrDefault(userPoolData.PrincipalNameKey),
            });
            if (userGetResult.IsError())
            {
                _logger.LogWarning("user not found, will assume user isn't created yet");
                var userCreateResult = _userService.Create(new UserCreateRequestModel
                {
                    PrincipalName = dictionaryOfUserInfo.GetValueOrDefault(userPoolData.PrincipalNameKey),
                    UserAttributes = dictionaryOfUserInfo,
                    UserPoolId = userPoolData.Id
                });
                if (userCreateResult.IsError())
                {
                    _logger.LogError(userCreateResult.ErrorMessage);
                    return new FuncResponse<AuthLoginResponseModel>
                    {
                        ErrorMessage = "failed to create user"
                    };
                }
            }

            _logger.LogInformation("user already exists, will continue to update user attributes");
            foreach (var attribute in dictionaryOfUserInfo)
            {
                if (attribute.Value == null)
                {
                    continue;
                }

                if (userGetResult.Data.UserAttributes.ContainsKey(attribute.Key))
                {
                    var createAttributeResult = _userService.CreateAttribute(new UserAttributeCreateRequestModel
                    {
                        UserId = userGetResult.Data.Id,
                        Key = attribute.Key,
                        Value = attribute.Value
                    });
                    if (createAttributeResult.IsError())
                    {
                        _logger.LogWarning("create user attribute error");
                        continue;
                    }
                    _logger.LogInformation($"create user attribute {attribute.Key}");
                    continue;
                }

                var updateAttributeResult = _userService.UpdateAttribute(new UserAttributeUpdateRequestModel
                {
                    UserId = userGetResult.Data.Id,
                    Key = attribute.Key,
                    Value = attribute.Value
                });
                if (updateAttributeResult.IsError())
                {
                    _logger.LogWarning("update user attribute error");
                    continue;
                }
                _logger.LogInformation($"update user attribute key {attribute.Key}");
            }

            return new FuncResponse<AuthLoginResponseModel>
            {
                Data = new AuthLoginResponseModel
                {
                    AccessToken = "token",
                    RefreshToken = "reftoken"
                }
            };

        }
    }
}
