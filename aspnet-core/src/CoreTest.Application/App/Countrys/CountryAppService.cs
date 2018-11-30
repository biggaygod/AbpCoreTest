using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Runtime.Caching;
using CoreTest.App.Countrys.Dto;
using CoreTest.Authorization;
using CoreTest.BaseDto;
using CoreTest.Common;
using CoreTest.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreTest.App.Countrys
{
    [AbpAuthorize(PermissionNames.Pages_Countrys)]
    public class CountryAppService : AsyncCrudAppService<Country, CountryDto, int, PageResultRequestSearch, CreateCountryDto, CountryDto>, ICountryAppService
    {
        private readonly ICacheManager cacheManager;

        public CountryAppService(IRepository<Country, int> repository, ICacheManager cacheManage) : base(repository)
        {
            cacheManager = cacheManage;
        }

        #region 增删改查
        public override async Task<CountryDto> Create(CreateCountryDto input)
        {
            CheckCreatePermission();

            var Country = ObjectMapper.Map<Country>(input);

            Country.TenantId = AbpSession.TenantId;

            await Repository.InsertAsync(Country);

            return MapToEntityDto(Country);
        }

        public override async Task<CountryDto> Update(CountryDto input)
        {
            CheckUpdatePermission();

            var Country = await Repository.GetAsync(input.Id);

            MapToEntity(input, Country);

            await Repository.UpdateAsync(Country);

            return await Get(input);
        }

        public override async Task Delete(EntityDto<int> input)
        {
            var Country = await Repository.GetAsync(input.Id);

            await Repository.DeleteAsync(Country);
        }

        public override async Task<PagedResultDto<CountryDto>> GetAll(PageResultRequestSearch input)
        {
            CommonMethod method = new CommonMethod();
            var sql = method.BuildSqlWhere(input.where, "C_Country");
            var lists = Repository.GetAll().Skip(input.SkipCount).Take(input.MaxResultCount);
            var items = ObjectMapper.Map<List<CountryDto>>(lists);
            return await Task.FromResult(new PagedResultDto<CountryDto>(input.MaxResultCount, items));
        }
        #endregion
    }
}
