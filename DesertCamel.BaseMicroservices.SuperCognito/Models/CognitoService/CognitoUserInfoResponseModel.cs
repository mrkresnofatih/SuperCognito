using Newtonsoft.Json;

namespace DesertCamel.BaseMicroservices.SuperCognito.Models.CognitoService
{
    public class CognitoUserInfoResponseModel : OidcUserInfoModel
    {
        [JsonProperty("username")]
        public string? Username { get; set; }
    }
}
