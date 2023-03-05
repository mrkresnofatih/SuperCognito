namespace DesertCamel.BaseMicroservices.SuperCognito.Models.UserService
{
    public class UserAttributeUpdateResponseModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
