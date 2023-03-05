using DesertCamel.BaseMicroservices.SuperCognito.Models;
using DesertCamel.BaseMicroservices.SuperCognito.Models.ResourceService;
using DesertCamel.BaseMicroservices.SuperCognito.Services.ResourceService;
using Microsoft.AspNetCore.Mvc;

namespace DesertCamel.BaseMicroservices.SuperCognito.Controllers
{
    [ApiController]
    [Route("resource")]
    public class ResourceController : ControllerBase
    {
        private readonly ILogger<ResourceController> _logger;
        private readonly IResourceService _resourceService;

        public ResourceController(
            ILogger<ResourceController> logger,
            IResourceService resourceService)
        {
            _logger = logger;
            _resourceService = resourceService;
        }

        [HttpPost("create")]
        public async Task<FuncResponse<ResourceCreateResponseModel>> Create([FromBody] ResourceCreateRequestModel requestModel)
        {
            var createResult = await _resourceService.Create(requestModel);
            if (createResult.IsError())
            {
                _logger.LogError("resource create failed");
                return new FuncResponse<ResourceCreateResponseModel>
                {
                    Data = null,
                    ErrorMessage = "resource create failed"
                };
            }
            return createResult;
        }

        [HttpPost("get")]
        public async Task<FuncResponse<ResourceGetResponseModel>> Get([FromBody] ResourceGetRequestModel getModel)
        {
            var getResult = await _resourceService.Get(getModel);
            if (getResult.IsError())
            {
                _logger.LogError("get resource failed");
                return new FuncResponse<ResourceGetResponseModel>
                {
                    Data = null,
                    ErrorMessage = "get resource failed"
                };
            }
            return getResult;
        }

        [HttpPost("list")]
        public async Task<FuncListResponse<ResourceGetResponseModel>> List([FromBody] ResourceListRequestModel listModel)
        {
            var getResult = await _resourceService.List(listModel);
            if (getResult.IsError())
            {
                _logger.LogError("list resource failed");
                return new FuncListResponse<ResourceGetResponseModel>
                {
                    ErrorMessage = "list resource fail"
                };
            }
            return getResult;
        }

        [HttpPost("update")]
        public async Task<FuncResponse<ResourceUpdateResponseModel>> Update([FromBody] ResourceUpdateRequestModel updateModel)
        {
            var updateResult = await _resourceService.Update(updateModel);
            if (updateResult.IsError())
            {
                _logger.LogError("update resource failed");
                return new FuncResponse<ResourceUpdateResponseModel>
                {
                    ErrorMessage = "update resource failed"
                };
            }
            return updateResult;
        }

        [HttpPost("delete")]
        public async Task<FuncResponse<ResourceDeleteResponseModel>> Delete([FromBody] ResourceDeleteRequestModel deleteModel)
        {
            var deleteResult = await _resourceService.Delete(deleteModel);
            if (deleteResult.IsError())
            {
                _logger.LogError("delete resource failed");
                return new FuncResponse<ResourceDeleteResponseModel>
                {
                    ErrorMessage = "delete resource failed"
                };
            }
            return deleteResult;
        }
    }
}
