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
using CoreTest.Entities;
using CoreTest.IRepositories;
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
    public class BrandAppService: IBrandAppService
    {
        private readonly IBrandRepository brandRepository;
        private readonly ICacheManager cacheManager;

        public BrandAppService(IBrandRepository brandRepository, ICacheManager cacheManage)
        {
            this.brandRepository = brandRepository;
            this.cacheManager = cacheManage;
        }

        private const string BrandCache = "Brand";
        private const string AllBrandCache = "AllBrand";

        public List<CreateBrandDto> GetAllBrand()
        {
            return cacheManager.GetCache(BrandCache).Get(AllBrandCache, () => GetCreateBrandDtoList());
        }


        private List<CreateBrandDto> GetCreateBrandDtoList()
        {
            //var countryList = countryRepository.GetAll();
            var CreateBrandDtoList = brandRepository.GetAll().MapTo<List<CreateBrandDto>>();
            //foreach (var item in CreateBrandDtoList)
            //{
            //    var country = countryList.Where(t => t.CountryCode == item.CountryCode).FirstOrDefault();
            //    if (country != null)
            //        item.CountryName = country.CountryName;
            //}
            return CreateBrandDtoList;
        }

        /// <summary>
        /// 创建品牌
        /// </summary>
        /// <param name="inputDto"></param>
        /// <returns></returns>
        public int CreateBrand(BrandDto inputDto)
        {
            var Brand = inputDto.MapTo<Brand>();
            int Id = brandRepository.InsertAndGetId(Brand);
            cacheManager.GetCache(BrandCache).Clear();
            return Id;
        }

        /// <summary>
        /// 更新品牌
        /// </summary>
        /// <param name="inputDto"></param>
        public void UpdateBrand(BrandDto inputDto)
        {
            if (inputDto.Id.HasValue)
            {
                var Brand = brandRepository.Get(inputDto.Id.Value);
                if (Brand != null)
                {
                    Brand.CountryCode = inputDto.CountryCode;
                    Brand.BrandName = inputDto.BrandName;
                    Brand.EngName = inputDto.EngName;
                    Brand.Spell = inputDto.Spell;
                }
                brandRepository.Update(Brand);
                cacheManager.GetCache(BrandCache).Clear();
            }
        }

        /// <summary>
        /// 删除品牌信息
        /// </summary>
        /// <param name="BrandId"></param>
        public void DeleteBrand(int BrandId)
        {
            var Brand = brandRepository.Get(BrandId);
            if (Brand != null)
            {
                brandRepository.Delete(Brand);
            }
            cacheManager.GetCache(BrandCache).Clear();
        }

        /// <summary>
        /// 根据ID获取品牌信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BrandDto GetBrand(int id)
        {
            var Brand = brandRepository.Get(id);
            if (Brand != null)
                return Brand.MapTo<BrandDto>();
            else
                return new BrandDto();
        }

        /// <summary>
        /// 获得品牌列表信息
        /// </summary>
        /// <returns></returns>
        public List<BrandDto> SearchBrandList()
        {
            var Brand = brandRepository.GetAll();
            return Brand.MapTo<List<BrandDto>>();
        }

        /// <summary>
        /// 重新启动品牌
        /// </summary>
        /// <param name="BrandId"></param>
        /// <param name="userId"></param>
        public void StartBrand(int BrandId)
        {
            var Brand = brandRepository.Get(BrandId);
            if (Brand != null)
            {
                Brand.IsActive = true;
                brandRepository.Update(Brand);
                cacheManager.GetCache(BrandCache).Clear();
            }
        }

        /// <summary>
        /// 停用品牌
        /// </summary>
        /// <param name="BrandId"></param>
        /// <param name="userId"></param>
        public void StopBrand(int BrandId)
        {
            var Brand = brandRepository.Get(BrandId);
            if (Brand != null)
            {
                Brand.IsActive = false;
                brandRepository.Update(Brand);
                cacheManager.GetCache(BrandCache).Clear();
            }
        }
    }
}
