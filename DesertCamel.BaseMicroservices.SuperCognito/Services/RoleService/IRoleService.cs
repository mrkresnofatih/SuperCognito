using DesertCamel.BaseMicroservices.SuperCognito.Models;
using DesertCamel.BaseMicroservices.SuperCognito.Models.RoleService;

namespace DesertCamel.BaseMicroservices.SuperCognito.Services.RoleService
{
    public interface IRoleService
    {
        Task<FuncResponse<RoleCreateResponseModel>> CreateRole(RoleCreateRequestModel createRequest);

        Task<FuncListResponse<RoleGetResponseModel>> ListRoles(RoleListRequestModel listRequest);

        Task<FuncResponse<RoleGetResponseModel>> GetRole(RoleGetRequestModel getRequest);

        Task<FuncResponse<RoleUpdateResponseModel>> UpdateRole(RoleUpdateRequestModel updateRequest);

        Task<FuncResponse<RoleDeleteResponseModel>> DeleteRole(RoleDeleteRequestModel deleteRequest);
    }
}
