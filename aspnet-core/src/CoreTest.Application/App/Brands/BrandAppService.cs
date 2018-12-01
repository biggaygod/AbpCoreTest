using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.EntityFrameworkCore;
using Abp.Runtime.Caching;
using AutoMapper.QueryableExtensions;
using CoreTest.Authorization;
using CoreTest.BaseDto;
using CoreTest.Brands.Dto;
using CoreTest.Common;
using CoreTest.Entities.Base;
using CoreTest.Entities.Customer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CoreTest.Brands
{
    [AbpAuthorize(PermissionNames.Pages_Brands)]
    public class BrandAppService: AsyncCrudAppService<Brand, BrandDto, int, PageResultRequestSearch, CreateBrandDto, BrandDto>,IBrandAppService
    {
        private readonly ICacheManager _cacheManager;

        private readonly IRepository<Country> _countryRepository;


        public BrandAppService(IRepository<Brand, int> repository, 
            ICacheManager cacheManager,
            IRepository<Country> countryRepository
            ) :base(repository)
        {
            _cacheManager = cacheManager;
            _countryRepository = countryRepository;
        }

        #region 增删改查
        public override async Task<BrandDto> Create(CreateBrandDto input)
        {
            CheckCreatePermission();

            var brand = ObjectMapper.Map<Brand>(input);

            brand.TenantId = AbpSession.TenantId;

            await Repository.InsertAsync(brand);

            return MapToEntityDto(brand);
        }

        public override async Task<BrandDto> Update(BrandDto input)
        {
            CheckUpdatePermission();

            var brand = await Repository.GetAsync(input.Id);

            MapToEntity(input, brand);

            await Repository.UpdateAsync(brand);

            return await Get(input);
        }

        public override async Task Delete(EntityDto<int> input)
        {
            CheckDeletePermission();
            var brand = await Repository.GetAsync(input.Id);

            await Repository.DeleteAsync(brand);
        }


        public override async Task<PagedResultDto<BrandDto>> GetAll(PageResultRequestSearch input)
        {
            CommonMethod method = new CommonMethod();
            var sql = method.BuildSqlWhere(input.where, "dbo.CRM_Brand");

            CheckGetAllPermission();

            var query = CreateFilteredQuery(input).FromSql(sql);

            var totalCount = await AsyncQueryableExecuter.CountAsync(query);

            query = ApplySorting(query, input);

            query = ApplyPaging(query, input);

            var entities = await AsyncQueryableExecuter.ToListAsync(query);

            return new PagedResultDto<BrandDto>(
                totalCount,
                entities.Select(MapToEntityDto).ToList()
            );
        }

        protected override BrandDto MapToEntityDto(Brand entity)
        {
            var countrys = _countryRepository.GetAll();
            var country = countrys.Where(u => u.CountryCode == entity.CountryCode).FirstOrDefault();
            var item = ObjectMapper.Map<BrandDto>(entity);
            item.CountryName = country == null ? string.Empty : country.CountryName;
            return item;
        }
        #endregion
    }
}
