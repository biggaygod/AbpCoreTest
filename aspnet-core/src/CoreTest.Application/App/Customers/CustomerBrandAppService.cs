using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Runtime.Caching;
using CoreTest.App.Customers.Dto;
using CoreTest.Authorization;
using CoreTest.BaseDto;
using CoreTest.Common;
using CoreTest.Entities.Customer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreTest.App.Customers
{
    [AbpAuthorize(PermissionNames.Pages_Customers)]
    public class CustomerBrandAppService : AsyncCrudAppService<CustomerBrand, CustomerBrandDto, int, PageResultRequestSearch, CreateCustomerBrandDto, CustomerBrandDto>, IApplicationService, ICustomerBrandAppService
    {
        private readonly ICacheManager _cacheManager;



        public CustomerBrandAppService(IRepository<CustomerBrand, int> repository,
            ICacheManager cacheManager
            ) : base(repository)
        {
            _cacheManager = cacheManager;
        }

        #region 增删改查
        public override async Task<CustomerBrandDto> Create(CreateCustomerBrandDto input)
        {
            CheckCreatePermission();

            var CustomerBrand = ObjectMapper.Map<CustomerBrand>(input);

            CustomerBrand.TenantId = AbpSession.TenantId;

            await Repository.InsertAsync(CustomerBrand);

            return MapToEntityDto(CustomerBrand);
        }

        public override async Task<CustomerBrandDto> Update(CustomerBrandDto input)
        {
            CheckUpdatePermission();

            var CustomerBrand = await Repository.GetAsync(input.Id);

            MapToEntity(input, CustomerBrand);

            await Repository.UpdateAsync(CustomerBrand);

            return await Get(input);
        }

        public override async Task Delete(EntityDto<int> input)
        {
            CheckDeletePermission();
            var CustomerBrand = await Repository.GetAsync(input.Id);

            await Repository.DeleteAsync(CustomerBrand);
        }


        public override async Task<PagedResultDto<CustomerBrandDto>> GetAll(PageResultRequestSearch input)
        {
            CommonMethod method = new CommonMethod();
            var sql = method.BuildSqlWhere(input.where, "dbo.CRM_CustomerBrand");

            CheckGetAllPermission();

            var query = CreateFilteredQuery(input).FromSql(sql);

            var totalCount = await AsyncQueryableExecuter.CountAsync(query);

            query = ApplySorting(query, input);

            query = ApplyPaging(query, input);

            var entities = await AsyncQueryableExecuter.ToListAsync(query);

            return new PagedResultDto<CustomerBrandDto>(
                totalCount,
                entities.Select(MapToEntityDto).ToList()
            );
        }
        #endregion
    }
}
