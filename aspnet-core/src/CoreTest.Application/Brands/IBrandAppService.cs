using Abp.Application.Services;
using Abp.Application.Services.Dto;
using CoreTest.Brands.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreTest.Brands
{
    public interface IBrandAppService : IApplicationService
    {
        /// <summary>
        /// 获取品牌列表
        /// </summary>
        /// <returns></returns>
        List<CreateBrandDto> GetAllBrand();
        /// <summary>
        /// 创建品牌
        /// </summary>
        /// <param name="inputDto">input品牌类</param>
        /// <returns></returns>
        int CreateBrand(BrandDto inputDto);

        /// <summary>
        /// 更新品牌信息
        /// </summary>
        /// <param name="inputDto"></param>
        void UpdateBrand(BrandDto inputDto);

        /// <summary>
        /// 删除品牌信息
        /// </summary>
        /// <param name="BrandId"></param>
        void DeleteBrand(int BrandId);

        /// <summary>
        /// 根据ID获取品牌信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        BrandDto GetBrand(int id);

        /// <summary>
        /// 获得品牌列表信息
        /// </summary>
        /// <returns></returns>
        List<BrandDto> SearchBrandList();

        /// <summary>
        /// 重新启动品牌
        /// </summary>
        /// <param name="BrandId"></param>
        /// <param name="userId"></param>
        void StartBrand(int BrandId);

        /// <summary>
        /// 停用品牌
        /// </summary>
        /// <param name="BrandId"></param>
        /// <param name="userId"></param>
        void StopBrand(int BrandId);
    }
}
