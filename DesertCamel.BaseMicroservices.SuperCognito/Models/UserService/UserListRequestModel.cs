namespace DesertCamel.BaseMicroservices.SuperCognito.Models.UserService
{
    public class UserListRequestModel
    {
        public string QuickSearch { get; set; }
        public long Page { get; set; }
        public long PageSize { get; set; }
    }
}
