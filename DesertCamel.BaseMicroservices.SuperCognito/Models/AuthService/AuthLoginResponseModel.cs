namespace DesertCamel.BaseMicroservices.SuperCognito.Models.AuthService
{
    public class AuthLoginResponseModel
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
