using DesertCamel.BaseMicroservices.SuperCognito.Models;
using DesertCamel.BaseMicroservices.SuperCognito.Models.UserPoolService;

namespace DesertCamel.BaseMicroservices.SuperCognito.Services.UserPoolService
{
    public interface IUserPoolService
    {
        Task<FuncResponse<UserPoolCreateResponseModel>> CreateUserPool(UserPoolCreateRequestModel createRequest);

        Task<FuncResponse<UserPoolGetResponseModel>> GetUserPool(UserPoolGetRequestModel getRequest);

        Task<FuncListResponse<UserPoolGetResponseModel>> ListUserPools(UserPoolListRequestModel listRequest);

        Task<FuncListResponse<UserPoolListActiveItemResponseModel>> ListActiveUserPools(UserPoolListActiveRequestModel listActiveRequest);
        Task<FuncResponse<UserPoolDeleteResponseModel>> DeleteUserPool(UserPoolDeleteRequestModel deleteRequest);

        Task<FuncResponse<UserPoolUpdateResponseModel>> UpdateUserPool(UserPoolUpdateRequestModel updateRequest);
    }
}
