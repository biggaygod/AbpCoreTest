using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Runtime.Caching;
using CoreTest.App.Customers.Dto;
using CoreTest.Authorization;
using CoreTest.BaseDto;
using CoreTest.Common;
using CoreTest.Entities.Base;
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
    public class CustomerAppService:AsyncCrudAppService<Customer, CustomerDto, int, PageResultRequestSearch, CreateCustomerDto, CustomerDto>, IApplicationService,ICustomerAppService
    {
        private readonly ICacheManager _cacheManager;

        private readonly IRepository<Country> _countryRepository;


        public CustomerAppService(IRepository<Customer,int> repository,
            ICacheManager cacheManager,
            IRepository<Country> countryRepository
            ) : base(repository)
        {
            _cacheManager = cacheManager;
            _countryRepository = countryRepository;
        }

        #region 增删改查
        public override async Task<CustomerDto> Create(CreateCustomerDto input)
        {
            CheckCreatePermission();

            var Customer = ObjectMapper.Map<Customer>(input);

            Customer.TenantId = AbpSession.TenantId;

            await Repository.InsertAsync(Customer);

            return MapToEntityDto(Customer);
        }

        public override async Task<CustomerDto> Update(CustomerDto input)
        {
            CheckUpdatePermission();

            var Customer = await Repository.GetAsync(input.Id);

            MapToEntity(input, Customer);

            await Repository.UpdateAsync(Customer);

            return await Get(input);
        }

        public override async Task Delete(EntityDto<int> input)
        {
            CheckDeletePermission();
            var Customer = await Repository.GetAsync(input.Id);

            await Repository.DeleteAsync(Customer);
        }


        public override async Task<PagedResultDto<CustomerDto>> GetAll(PageResultRequestSearch input)
        {
            CommonMethod method = new CommonMethod();
            var sql = method.BuildSqlWhere(input.where, "dbo.CRM_Customer");

            CheckGetAllPermission();

            var query = CreateFilteredQuery(input).FromSql(sql);

            var totalCount = await AsyncQueryableExecuter.CountAsync(query);

            query = ApplySorting(query, input);

            query = ApplyPaging(query, input);

            var entities = await AsyncQueryableExecuter.ToListAsync(query);

            return new PagedResultDto<CustomerDto>(
                totalCount,
                entities.Select(MapToEntityDto).ToList()
            );
        }

        protected override CustomerDto MapToEntityDto(Customer entity)
        {
            var item = ObjectMapper.Map<CustomerDto>(entity);
            return item;
        }
        #endregion
    }
}
