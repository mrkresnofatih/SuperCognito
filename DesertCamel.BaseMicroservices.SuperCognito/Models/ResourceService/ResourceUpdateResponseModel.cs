namespace DesertCamel.BaseMicroservices.SuperCognito.Models.ResourceService
{
    public class ResourceUpdateResponseModel
    {
        public Guid Id { get; set; }
        public Guid RoleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
