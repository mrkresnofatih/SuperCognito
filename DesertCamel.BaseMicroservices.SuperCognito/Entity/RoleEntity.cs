using System.ComponentModel.DataAnnotations;

namespace DesertCamel.BaseMicroservices.SuperCognito.Entity
{
    public class RoleEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Description { get; set; }

        public List<ResourceEntity> Resources { get; set; }
        public List<PermissionEntity> Permissions { get; set; }
    }
}
