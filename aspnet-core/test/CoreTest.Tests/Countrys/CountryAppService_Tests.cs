using Abp.Application.Services.Dto;
using CoreTest.App.Countrys;
using CoreTest.App.Countrys.Dto;
using CoreTest.BaseDto;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CoreTest.Tests.Countrys
{
    public class CountryAppService_Tests: CoreTestTestBase
    {
        private readonly ICountryAppService _countryAppService;

        public CountryAppService_Tests()
        {
            _countryAppService = Resolve<ICountryAppService>();
        }

        [Fact]
        public async Task GetCountrys_Test()
        {
            // Act
            var output = await _countryAppService.GetAll(new PageResultRequestSearch { MaxResultCount = 20, SkipCount = 0, where = string.Empty, Sorting = null });

            // Assert
            output.Items.Count.ShouldBeGreaterThan(0);
        }

        [Fact]
        public async Task CreateCountry_Test()
        {
            // Act
            await _countryAppService.Create(
                new CreateCountryDto
                {
                    CountryCode = "TestCN",
                    IsActive = true,
                    CountryName="中国测试",
                    CountryShort= "TestCN",
                    EnglishName= "TestChina"
                });

            await UsingDbContextAsync(async context =>
            {
                var johnNashCountry = await context.Country.FirstOrDefaultAsync(u => u.CountryCode == "TestCN");
                johnNashCountry.ShouldNotBeNull();
            });
        }
    }
}
