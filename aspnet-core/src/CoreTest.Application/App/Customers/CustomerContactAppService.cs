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
    public class CustomerContactAppService : AsyncCrudAppService<CustomerContact, CustomerContactDto, int, PageResultRequestSearch, CreateCustomerContactDto, CustomerContactDto>, IApplicationService, ICustomerContactAppService
    {
        private readonly ICacheManager _cacheManager;

        private readonly IRepository<Customer> _customerRepository;

        public CustomerContactAppService(IRepository<CustomerContact, int> repository,
            ICacheManager cacheManager,
            IRepository<Customer> customerRepository
            ) : base(repository)
        {
            _cacheManager = cacheManager;
            _customerRepository = customerRepository;
        }

        #region 增删改查
        public override async Task<CustomerContactDto> Create(CreateCustomerContactDto input)
        {
            CheckCreatePermission();

            var CustomerContact = ObjectMapper.Map<CustomerContact>(input);

            CustomerContact.TenantId = AbpSession.TenantId;

            await Repository.InsertAsync(CustomerContact);

            return MapToEntityDto(CustomerContact);
        }

        public override async Task<CustomerContactDto> Update(CustomerContactDto input)
        {
            CheckUpdatePermission();

            var CustomerContact = await Repository.GetAsync(input.Id);

            MapToEntity(input, CustomerContact);

            await Repository.UpdateAsync(CustomerContact);

            return await Get(input);
        }

        public override async Task Delete(EntityDto<int> input)
        {
            CheckDeletePermission();
            var CustomerContact = await Repository.GetAsync(input.Id);

            await Repository.DeleteAsync(CustomerContact);
        }


        public override async Task<PagedResultDto<CustomerContactDto>> GetAll(PageResultRequestSearch input)
        {
            CommonMethod method = new CommonMethod();
            var sql = method.BuildSqlWhere(input.where, "dbo.CRM_CustomerContact");

            CheckGetAllPermission();

            var query = CreateFilteredQuery(input).FromSql(sql);

            var totalCount = await AsyncQueryableExecuter.CountAsync(query);

            query = ApplySorting(query, input);

            query = ApplyPaging(query, input);

            var entities = await AsyncQueryableExecuter.ToListAsync(query);

            return new PagedResultDto<CustomerContactDto>(
                totalCount,
                entities.Select(MapToEntityDto).ToList()
            );
        }
        #endregion
    }
}
