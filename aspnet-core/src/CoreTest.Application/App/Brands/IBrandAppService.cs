using Abp.Application.Services;
using Abp.Application.Services.Dto;
using CoreTest.BaseDto;
using CoreTest.Brands.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreTest.Brands
{
    public interface IBrandAppService : IAsyncCrudAppService<BrandDto, int, PageResultRequestSearch, CreateBrandDto, BrandDto>,IApplicationService
    {
    }
}
