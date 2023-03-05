using System.ComponentModel.DataAnnotations;

namespace DesertCamel.BaseMicroservices.SuperCognito.Models.AuthService
{
    public class AuthLoginRequestModel
    {
        [Required]
        public Guid UserPoolId { get; set; }

        [Required]
        [MaxLength(100)]
        public string AuthorizationCode { get; set; }
    }
}
