using Newtonsoft.Json;

namespace DesertCamel.BaseMicroservices.SuperCognito.Models.CognitoService
{
    public class CognitoExchangeTokenResponseModel
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
        [JsonProperty("id_token")]
        public string IdToken { get; set; }
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }
        [JsonProperty("token_type")]
        public string TokenType { get; set; }
        [JsonProperty("error")]
        public string Error { get; set; }
    }
}
