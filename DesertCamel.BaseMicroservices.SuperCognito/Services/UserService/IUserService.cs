using DesertCamel.BaseMicroservices.SuperCognito.Models;
using DesertCamel.BaseMicroservices.SuperCognito.Models.UserService;

namespace DesertCamel.BaseMicroservices.SuperCognito.Services.UserService
{
    public interface IUserService
    {
        FuncResponse<UserCreateResponseModel> Create(UserCreateRequestModel createRequest);

        FuncResponse<UserGetResponseModel> Get(UserGetRequestModel getRequest);

        FuncListResponse<UserGetResponseModel> List(UserListRequestModel listRequest);

        FuncResponse<UserDeleteResponseModel> Delete(UserDeleteRequestModel deleteRequest);

        FuncResponse<UserAttributeCreateResponseModel> CreateAttribute(UserAttributeCreateRequestModel createRequest);

        FuncResponse<UserAttributeUpdateResponseModel> UpdateAttribute(UserAttributeUpdateRequestModel updateRequest);
    }
}
