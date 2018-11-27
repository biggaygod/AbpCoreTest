using Abp.Application.Services;
using Abp.Application.Services.Dto;
using CoreTest.Brands.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreTest.Brands
{
    public interface IBrandAppService : IAsyncCrudAppService<BrandDto, int, PagedResultRequestDto, CreateBrandDto, BrandDto>,IApplicationService
    {
        
    }
}
