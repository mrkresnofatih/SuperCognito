using DesertCamel.BaseMicroservices.SuperCognito.Models;
using DesertCamel.BaseMicroservices.SuperCognito.Models.AuthService;

namespace DesertCamel.BaseMicroservices.SuperCognito.Services.AuthService
{
    public interface IAuthService
    {
        FuncResponse<AuthLoginResponseModel> Login(AuthLoginRequestModel loginRequest);
    }
}
