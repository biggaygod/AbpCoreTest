using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.Runtime.Caching;
using AutoMapper.QueryableExtensions;
using CoreTest.Authorization;
using CoreTest.Brands.Dto;
using CoreTest.Entities.Customer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreTest.Brands
{
    [AbpAuthorize(PermissionNames.Pages_Brands)]
    public class BrandAppService: AsyncCrudAppService<Brand, BrandDto, int, PagedResultRequestDto, CreateBrandDto, BrandDto>,IBrandAppService
    {
        private readonly ICacheManager cacheManager;

        public BrandAppService(IRepository<Brand, int> repository, ICacheManager cacheManage ):base(repository)
        {
            cacheManager = cacheManage;
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
            var brand = await Repository.GetAsync(input.Id);

            await Repository.DeleteAsync(brand);
        }
        #endregion


    }
}
