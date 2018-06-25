using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AssetManagement.MultiTenancy.Dto;

namespace AssetManagement.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
