namespace DesertCamel.BaseMicroservices.SuperCognito.Models.ResourceService
{
    public class ResourceUpdateRequestModel
    {
        public string ResourceName { get; set; }

        public Guid RoleId { get; set; }

        public string Description { get; set; }
    }
}
