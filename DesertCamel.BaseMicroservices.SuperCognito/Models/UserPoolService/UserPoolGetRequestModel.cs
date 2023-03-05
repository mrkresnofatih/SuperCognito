using System.ComponentModel.DataAnnotations;

namespace DesertCamel.BaseMicroservices.SuperCognito.Models.UserPoolService
{
    public class UserPoolGetRequestModel
    {
        [Required]
        public Guid UserPoolId { get; set; }
    }
}
