using DesertCamel.BaseMicroservices.SuperCognito.Models;
using DesertCamel.BaseMicroservices.SuperCognito.Models.ResourceService;

namespace DesertCamel.BaseMicroservices.SuperCognito.Services.ResourceService
{
    public interface IResourceService
    {
        Task<FuncResponse<ResourceCreateResponseModel>> Create(ResourceCreateRequestModel createRequest);
        Task<FuncResponse<ResourceUpdateResponseModel>> Update(ResourceUpdateRequestModel createRequest);
        Task<FuncResponse<ResourceGetResponseModel>> Get(ResourceGetRequestModel createRequest);
        Task<FuncListResponse<ResourceGetResponseModel>> List(ResourceListRequestModel listRequest);
        Task<FuncResponse<ResourceDeleteResponseModel>> Delete(ResourceDeleteRequestModel deleteRequest);
    }
}
