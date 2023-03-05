using DesertCamel.BaseMicroservices.SuperCognito.Models;
using DesertCamel.BaseMicroservices.SuperCognito.Models.CognitoService;

namespace DesertCamel.BaseMicroservices.SuperCognito.Services.CognitoService
{
    public interface ICognitoService
    {
        FuncResponse<CognitoExchangeTokenResponseModel> ExchangeToken(CognitoExchangeTokenRequestModel requestModel);

        FuncResponse<CognitoUserInfoResponseModel> UserInfo(CognitoUserInfoRequestModel requestModel);
    }
}
