using Abp.Application.Services;
using Abp.Application.Services.Dto;
using CoreTest.MultiTenancy.Dto;

namespace CoreTest.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
