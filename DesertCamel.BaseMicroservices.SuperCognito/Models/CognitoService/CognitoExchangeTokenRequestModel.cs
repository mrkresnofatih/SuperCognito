namespace DesertCamel.BaseMicroservices.SuperCognito.Models.CognitoService
{
    public class CognitoExchangeTokenRequestModel
    {
        public string ExchangeTokenUrl { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string AuthorizationCode { get; set; }
        public string RedirectUri { get; set; }
    }
}
