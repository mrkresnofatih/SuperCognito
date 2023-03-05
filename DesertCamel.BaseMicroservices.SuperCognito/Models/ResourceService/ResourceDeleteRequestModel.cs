namespace DesertCamel.BaseMicroservices.SuperCognito.Models.ResourceService
{
    public class ResourceDeleteRequestModel
    {
        public string ResourceName { get; set; }

        public Guid RoleId { get; set; }
    }
}
