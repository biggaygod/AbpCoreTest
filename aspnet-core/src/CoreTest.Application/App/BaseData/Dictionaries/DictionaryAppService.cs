using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Runtime.Caching;
using CoreTest.App.BaseData.Dictionaries.Dto;
using CoreTest.BaseDto;
using CoreTest.Common;
using CoreTest.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreTest.App.BaseData.Dictionaries
{
    public class DictionaryAppService : AsyncCrudAppService<Dictionary, DictionaryDto, int, PageResultRequestSearch, CreateDictionaryDto, DictionaryDto>, IDictionaryAppService
    {
        private readonly ICacheManager _cacheManager;

        private readonly IRepository<Country> _countryRepository;

        private readonly IRepository<DictionaryDetail> _dictionaryDetailRepository;


        public DictionaryAppService(IRepository<Dictionary, int> repository,
            ICacheManager cacheManager,
            IRepository<Country> countryRepository,
            IRepository<DictionaryDetail> dictionaryDetailRepository
            ) : base(repository)
        {
            _cacheManager = cacheManager;
            _countryRepository = countryRepository;
            _dictionaryDetailRepository = dictionaryDetailRepository;
        }

        #region 增删改查
        public override async Task<DictionaryDto> Create(CreateDictionaryDto input)
        {
            CheckCreatePermission();

            var dictionary = ObjectMapper.Map<Dictionary>(input);

            dictionary.TenantId = AbpSession.TenantId;

            await Repository.InsertAsync(dictionary);

            return MapToEntityDto(dictionary);
        }

        public override async Task<DictionaryDto> Update(DictionaryDto input)
        {
            CheckUpdatePermission();

            var dictionary = await Repository.GetAsync(input.Id);

            MapToEntity(input, dictionary);

            await Repository.UpdateAsync(dictionary);

            return await Get(input);
        }

        public override async Task Delete(EntityDto<int> input)
        {
            CheckDeletePermission();
            var dictionary = await Repository.GetAsync(input.Id);

            await Repository.DeleteAsync(dictionary);
        }


        public override async Task<PagedResultDto<DictionaryDto>> GetAll(PageResultRequestSearch input)
        {
            CommonMethod method = new CommonMethod();
            var sql = method.BuildSqlWhere(input.where, "dbo.Dic_Dictionary");

            CheckGetAllPermission();

            var query = CreateFilteredQuery(input).FromSql(sql);

            var totalCount = await AsyncQueryableExecuter.CountAsync(query);

            query = ApplySorting(query, input);

            query = ApplyPaging(query, input);

            var entities = await AsyncQueryableExecuter.ToListAsync(query);

            return new PagedResultDto<DictionaryDto>(
                totalCount,
                entities.Select(MapToEntityDto).ToList()
            );
        }

        protected override DictionaryDto MapToEntityDto(Dictionary entity)
        {
            //var countrys = _countryRepository.GetAll();
            //var country = countrys.Where(u => u.CountryCode == entity.CountryCode).FirstOrDefault();
            var item = ObjectMapper.Map<DictionaryDto>(entity);
            //item.CountryName = country == null ? string.Empty : country.CountryName;
            return item;
        }
        #endregion
    }
}
