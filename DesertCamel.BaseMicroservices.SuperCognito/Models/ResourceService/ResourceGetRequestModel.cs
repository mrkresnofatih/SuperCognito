using System.ComponentModel.DataAnnotations;

namespace DesertCamel.BaseMicroservices.SuperCognito.Models.ResourceService
{
    public class ResourceGetRequestModel
    {
        public string ResourceName { get; set; }

        [Required]
        public Guid RoleId { get; set; }
    }
}
