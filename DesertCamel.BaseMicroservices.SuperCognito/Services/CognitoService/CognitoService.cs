using DesertCamel.BaseMicroservices.SuperCognito.Models;
using DesertCamel.BaseMicroservices.SuperCognito.Models.CognitoService;
using DesertCamel.BaseMicroservices.SuperCognito.Utilities;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace DesertCamel.BaseMicroservices.SuperCognito.Services.CognitoService
{
    public class CognitoService : ICognitoService
    {
        private readonly ILogger<CognitoService> _logger;

        public CognitoService(
            ILogger<CognitoService> logger)
        {
            _logger = logger;
        }

        public FuncResponse<CognitoExchangeTokenResponseModel> ExchangeToken(CognitoExchangeTokenRequestModel requestModel)
        {
            try
            {
                _logger.LogInformation($"Start ExchangeToken w. data: {requestModel.ToJson()}");
                var httpClient = new HttpClient();
                var token = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes($"{requestModel.ClientId}:{requestModel.ClientSecret}"));
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Basic {token}");
                var formDictionary = new Dictionary<string, string>
                {
                    { "grant_type", "authorization_code" },
                    { "client_id", requestModel.ClientId },
                    { "code", requestModel.AuthorizationCode },
                    { "redirect_uri", requestModel.RedirectUri }
                };
                var result = httpClient.PostAsync(requestModel.ExchangeTokenUrl, new FormUrlEncodedContent(formDictionary)).Result;
                var responseBody = result.Content.ReadAsStringAsync().Result;
                _logger.LogInformation($"ResponseBody: {responseBody}");

                var data = JsonConvert.DeserializeObject<CognitoExchangeTokenResponseModel>(responseBody);

                if (result.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    throw new Exception($"exchange token status code is {(int)result.StatusCode}, response with error occurred: {data.ToJson()}");
                }

                _logger.LogInformation("success exchange token");
                return new FuncResponse<CognitoExchangeTokenResponseModel>
                {
                    Data = data
                };
            }
            catch(Exception e)
            {
                _logger.LogError(e, "failed to exchange token");
                return new FuncResponse<CognitoExchangeTokenResponseModel>
                {
                    ErrorMessage = "failed to exchange token"
                };
            }
        }

        public FuncResponse<CognitoUserInfoResponseModel> UserInfo(CognitoUserInfoRequestModel requestModel)
        {
            try
            {
                _logger.LogInformation($"Start get UserInfo w. data: {requestModel.ToJson()}");
                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {requestModel.AccessToken}");
                var result = httpClient.GetAsync(requestModel.UserInfoUrl).Result;

                var responseBody = result.Content.ReadAsStringAsync().Result;
                _logger.LogInformation($"ResponseBody: {responseBody}");

                if (result.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    throw new Exception($"result status code is {(int)result.StatusCode}");
                }

                _logger.LogInformation("success get userinfo");
                return new FuncResponse<CognitoUserInfoResponseModel>
                {
                    Data = JsonConvert.DeserializeObject<CognitoUserInfoResponseModel>(responseBody),
                };
            }
            catch(Exception e)
            {
                _logger.LogError(e, "failed to get user info");
                return new FuncResponse<CognitoUserInfoResponseModel>
                {
                    ErrorMessage = "failed to get user info"
                };
            }
        }
    }
}
