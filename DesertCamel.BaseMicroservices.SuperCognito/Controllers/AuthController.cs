using DesertCamel.BaseMicroservices.SuperCognito.Models;
using DesertCamel.BaseMicroservices.SuperCognito.Models.AuthService;
using DesertCamel.BaseMicroservices.SuperCognito.Services.AuthService;
using Microsoft.AspNetCore.Mvc;

namespace DesertCamel.BaseMicroservices.SuperCognito.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(
            IAuthService authService,
            ILogger<AuthController> logger)
        {
            _authService = authService;
            _logger = logger;
        }

        [HttpPost("login")]
        public FuncResponse<AuthLoginResponseModel> Login([FromBody] AuthLoginRequestModel requestModel)
        {
            var loginResult = _authService.Login(requestModel);
            if (loginResult.IsError())
            {
                throw new Exception(loginResult.ErrorMessage);
            }
            return loginResult;
        }
    }
}
