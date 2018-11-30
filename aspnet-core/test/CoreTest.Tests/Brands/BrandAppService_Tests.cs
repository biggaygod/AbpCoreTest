using CoreTest.BaseDto;
using CoreTest.Brands;
using CoreTest.Brands.Dto;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using System.Linq;

namespace CoreTest.Tests.Brands
{
    public class BrandAppService_Tests: CoreTestTestBase
    {
        private readonly IBrandAppService _brandAppService;

        public BrandAppService_Tests()
        {
            _brandAppService = Resolve<IBrandAppService>();
        }

        [Fact]
        public async void GetBrands_Test()
        {
            // Act
            var output =await _brandAppService.GetAll(new PageResultRequestSearch { MaxResultCount = 10, SkipCount = 0,where=" 1=1 ",Sorting=null });

            // Assert
            output.Items.Count.ShouldBeGreaterThan(0);
        }

        [Fact]
        public async Task CreateBrand_Test()
        {
            // Act
            await _brandAppService.Create(
                new CreateBrandDto
                {
                    CountryCode = "CN",
                    BrandName = "测试品牌",
                    EngName = "TestBrand",
                    Spell = "Test",
                    IsActive = true,
                });

            await UsingDbContextAsync(async context =>
            {
                var johnNashUser = await context.Brand.FirstOrDefaultAsync(u => u.BrandName == "测试品牌");
                johnNashUser.ShouldNotBeNull();
            });
        }

    }
}
