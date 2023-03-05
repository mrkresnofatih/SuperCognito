using System.ComponentModel.DataAnnotations;

namespace DesertCamel.BaseMicroservices.SuperCognito.Models.UserPoolService
{
    public class UserPoolDeleteRequestModel
    {
        [Required]
        public Guid UserPoolId { get; set; }
    }
}
