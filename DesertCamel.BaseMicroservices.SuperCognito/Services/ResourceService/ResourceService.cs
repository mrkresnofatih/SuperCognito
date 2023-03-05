using DesertCamel.BaseMicroservices.SuperCognito.Entity;
using DesertCamel.BaseMicroservices.SuperCognito.EntityFramework;
using DesertCamel.BaseMicroservices.SuperCognito.Models;
using DesertCamel.BaseMicroservices.SuperCognito.Models.ResourceService;
using DesertCamel.BaseMicroservices.SuperCognito.Utilities;
using Microsoft.EntityFrameworkCore;

namespace DesertCamel.BaseMicroservices.SuperCognito.Services.ResourceService
{
    public class ResourceService : IResourceService
    {
        private readonly SuperCognitoDbContext _superCognitoDbContext;
        private readonly ILogger<ResourceService> _logger;

        public ResourceService(
            SuperCognitoDbContext superCognitoDbContext,
            ILogger<ResourceService> logger)
        {
            _superCognitoDbContext = superCognitoDbContext;
            _logger = logger;
        }

        public async Task<FuncResponse<ResourceCreateResponseModel>> Create(ResourceCreateRequestModel createRequest)
        {
            try
            {
                _logger.LogInformation($"Start CreateResoure w. data: {createRequest.ToJson()}");
                var newResource = new ResourceEntity
                {
                    Id = Guid.NewGuid(),
                    Name = createRequest.Name,
                    Description = createRequest.Description,
                    RoleId = createRequest.RoleId,
                };

                await _superCognitoDbContext.Resources.AddAsync(newResource);
                await _superCognitoDbContext.SaveChangesAsync();

                _logger.LogInformation("Finish: CreateResource success");
                return new FuncResponse<ResourceCreateResponseModel>
                {
                    Data = new ResourceCreateResponseModel
                    {
                        Id = newResource.Id,
                        Name = newResource.Name,
                        Description = newResource.Description,
                        RoleId = newResource.RoleId
                    }
                };
            }
            catch(Exception e)
            {
                _logger.LogError(e, "CreateResourceAPI failed");
                return new FuncResponse<ResourceCreateResponseModel>
                {
                    ErrorMessage = "CreateResourceAPI failed"
                };
            }
        }

        public async Task<FuncResponse<ResourceDeleteResponseModel>> Delete(ResourceDeleteRequestModel deleteRequest)
        {
            try
            {
                _logger.LogInformation($"Start DeleteResource w. data: {deleteRequest.ToJson()}");
                var foundResource = await _superCognitoDbContext
                    .Resources
                    .Where(x => x.Name.Equals(deleteRequest.ResourceName) && x.RoleId.Equals(deleteRequest.RoleId))
                    .FirstOrDefaultAsync();
                if (foundResource == null)
                {
                    throw new Exception("resource for delete not found");
                }

                _superCognitoDbContext.Resources.Remove(foundResource);
                await _superCognitoDbContext.SaveChangesAsync();

                _logger.LogInformation("DeleteResourceAPI success");
                return new FuncResponse<ResourceDeleteResponseModel>
                {
                    Data = new ResourceDeleteResponseModel(),
                    ErrorMessage = null
                };
            }
            catch(Exception e)
            {
                _logger.LogError(e, "delete resource failed");
                return new FuncResponse<ResourceDeleteResponseModel>
                {
                    ErrorMessage = "delete resource failed"
                };
            }
        }

        public async Task<FuncResponse<ResourceGetResponseModel>> Get(ResourceGetRequestModel getRequest)
        {
            try
            {
                _logger.LogInformation($"Start GetResource w. data: {getRequest.ToJson()}");
                var foundResource = await _superCognitoDbContext
                    .Resources
                    .Where(x => x.Name.Equals(getRequest.ResourceName) && x.RoleId.Equals(getRequest.RoleId))
                    .FirstOrDefaultAsync();
                if (foundResource == null)
                {
                    throw new Exception("Resource not found");
                }

                _logger.LogInformation("GetResource success");
                return new FuncResponse<ResourceGetResponseModel>
                {
                    Data = new ResourceGetResponseModel
                    {
                        Id = foundResource.Id,
                        Name = foundResource.Name,
                        Description = foundResource.Description,
                        RoleId = foundResource.RoleId
                    }
                };
            }
            catch(Exception e)
            {
                _logger.LogError(e, "Get resource failed");
                return new FuncResponse<ResourceGetResponseModel>
                {
                    ErrorMessage = "Get resource failed"
                };
            }
        }

        public async Task<FuncListResponse<ResourceGetResponseModel>> List(ResourceListRequestModel listRequest)
        {
            try
            {
                _logger.LogInformation($"Start ListResources w. data: {listRequest.ToJson()}");
                var query = _superCognitoDbContext.Resources.AsQueryable();

                query = query.Where(x => x.RoleId.Equals(listRequest.RoleId));

                if (!String.IsNullOrWhiteSpace(listRequest.Name))
                {
                    query = query.Where(x => x.Name.Contains(listRequest.Name));
                }

                query = query.OrderBy(x => x.Name);

                var count = await query.CountAsync();
                var resources = await query
                    .Skip((int)(listRequest.PageSize * (listRequest.Page - 1)))
                    .Take((int) listRequest.PageSize)
                    .Select(x => new ResourceGetResponseModel
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Description = x.Description,
                        RoleId = x.RoleId
                    })
                    .ToListAsync();

                _logger.LogInformation("ListResources success");
                return new FuncListResponse<ResourceGetResponseModel>
                {
                    Data = resources,
                    Total = count
                };
            }
            catch(Exception e)
            {
                _logger.LogError(e, "ListResources failed");
                return new FuncListResponse<ResourceGetResponseModel>
                {
                    ErrorMessage = "ListResources failed"
                };
            }
        }

        public async Task<FuncResponse<ResourceUpdateResponseModel>> Update(ResourceUpdateRequestModel updateRequest)
        {
            try
            {
                var foundResource = await _superCognitoDbContext
                    .Resources
                    .Where(x => x.Name.Equals(updateRequest.ResourceName) && x.RoleId.Equals(updateRequest.RoleId))
                    .FirstOrDefaultAsync();
                if (foundResource == null)
                {
                    throw new Exception("Resource not found");
                }

                foundResource.Description = updateRequest.Description;

                _logger.LogInformation("success update resource");
                return new FuncResponse<ResourceUpdateResponseModel>
                {
                    Data = new ResourceUpdateResponseModel
                    {
                        Id = foundResource.Id,
                        Name = foundResource.Name,
                        Description = foundResource.Description,
                        RoleId = foundResource.RoleId
                    },
                };
            }
            catch(Exception e)
            {
                _logger.LogError(e, "UpdateResource failed");
                return new FuncResponse<ResourceUpdateResponseModel>
                {
                    ErrorMessage = "UpdateResource failed"
                };
            }
        }
    }
}
