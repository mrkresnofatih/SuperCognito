using System.ComponentModel.DataAnnotations;

namespace DesertCamel.BaseMicroservices.SuperCognito.Models.RoleService
{
    public class RoleDeleteRequestModel
    {
        [Required]
        public string Name { get; set; }
    }
}
