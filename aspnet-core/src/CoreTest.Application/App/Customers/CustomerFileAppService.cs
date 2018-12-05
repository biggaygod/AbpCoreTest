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
    public class CustomerFileAppService : AsyncCrudAppService<CustomerFile, CustomerFileDto, int, PageResultRequestSearch, CreateCustomerFileDto, CustomerFileDto>, IApplicationService, ICustomerFileAppService
    {
        private readonly ICacheManager _cacheManager;



        public CustomerFileAppService(IRepository<CustomerFile, int> repository,
            ICacheManager cacheManager
            ) : base(repository)
        {
            _cacheManager = cacheManager;
        }

        #region 增删改查
        public override async Task<CustomerFileDto> Create(CreateCustomerFileDto input)
        {
            CheckCreatePermission();

            var CustomerFile = ObjectMapper.Map<CustomerFile>(input);

            CustomerFile.TenantId = AbpSession.TenantId;

            await Repository.InsertAsync(CustomerFile);

            return MapToEntityDto(CustomerFile);
        }

        public override async Task<CustomerFileDto> Update(CustomerFileDto input)
        {
            CheckUpdatePermission();

            var CustomerFile = await Repository.GetAsync(input.Id);

            MapToEntity(input, CustomerFile);

            await Repository.UpdateAsync(CustomerFile);

            return await Get(input);
        }

        public override async Task Delete(EntityDto<int> input)
        {
            CheckDeletePermission();
            var CustomerFile = await Repository.GetAsync(input.Id);

            await Repository.DeleteAsync(CustomerFile);
        }


        public override async Task<PagedResultDto<CustomerFileDto>> GetAll(PageResultRequestSearch input)
        {
            CommonMethod method = new CommonMethod();
            var sql = method.BuildSqlWhere(input.where, "dbo.CRM_CustomerFile");

            CheckGetAllPermission();

            var query = CreateFilteredQuery(input).FromSql(sql);

            var totalCount = await AsyncQueryableExecuter.CountAsync(query);

            query = ApplySorting(query, input);

            query = ApplyPaging(query, input);

            var entities = await AsyncQueryableExecuter.ToListAsync(query);

            return new PagedResultDto<CustomerFileDto>(
                totalCount,
                entities.Select(MapToEntityDto).ToList()
            );
        }
        #endregion
    }
}
