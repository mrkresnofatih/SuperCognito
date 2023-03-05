using System.ComponentModel.DataAnnotations;

namespace DesertCamel.BaseMicroservices.SuperCognito.Models.RoleService
{
    public class RoleGetRequestModel
    {
        [Required]
        public string Name { get; set; }
    }
}
