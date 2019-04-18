using Abp.Application.Services.Dto;
using CoreTest.App.Countrys;
using CoreTest.App.Countrys.Dto;
using CoreTest.BaseDto;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public void GetCountrys_Test()
        {
            //Assert
            UsingDbContext(ctx =>
            {
                var initalCount = ctx.Country.Count();
                ctx.Country.FirstOrDefault(t => t.CountryCode == "TestCNS").ShouldBeNull();
                //Arrange
                var countryResult1=_countryAppService.Create(
                    new CreateCountryDto
                    {
                        CountryCode = "TestCNS",
                        IsActive = true,
                        CountryName = "中国测试S",
                        CountryShort = "TestCNS",
                        EnglishName = "TestChinaS"
                    });
                initalCount.ShouldBe(8);
                ctx.Country.FirstOrDefault(t => t.CountryCode == "TestCNS").ShouldNotBeNull();
                ctx.Country.Count().ShouldBe(initalCount + 1);
                countryResult1.Id.ShouldBeGreaterThan(0);             
            });
        }

        [Fact]
        public async Task CreateCountry_Test()
        {
            await UsingDbContextAsync(async context =>
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
            
                var johnNashCountry = await context.Country.FirstOrDefaultAsync(u => u.CountryCode == "TestCN");
                johnNashCountry.ShouldNotBeNull();
            });
        }

        [Fact]
        public void DeleteCountry_Test()
        {
            UsingDbContextAsync(async context =>
            {
                var initialCount = context.Country.Count();
                initialCount.ShouldBe(8);
                var defaultCountry = await context.Country.FirstOrDefaultAsync();
                await _countryAppService.Delete(new EntityDto<int>()
                {
                    Id = defaultCountry.Id
                });
                var country = context.Country.FirstOrDefault(u => u.Id == defaultCountry.Id);
                country.ShouldBeNull();
                context.Country.Count().ShouldBe(initialCount - 1);
            });
        }

        [Fact]
        public void UpdateCountry_Test()
        {
            UsingDbContext(async ctx =>
            {
                //Arrange 
                var Country = new CreateCountryDto
                {
                    CountryCode = "TestCN",
                    IsActive = false,
                    CountryName = "中国测试",
                    CountryShort = "TestCN",
                    EnglishName = "TestChina"
                };
                // Act
                var countryResult1 = await _countryAppService.Create(Country);

                var countryResult2 = await _countryAppService.Update(countryResult1);

                //Assert            
                countryResult1.ShouldNotBe(null);
                countryResult2.ShouldNotBe(null);
                countryResult1.Id.ShouldBe(countryResult2.Id);
                countryResult1.CountryCode.ShouldBe(countryResult2.CountryCode);
                countryResult1.CountryName.ShouldNotBe(countryResult2.CountryName);
                countryResult1.EnglishName.ShouldNotBe(countryResult2.EnglishName);
                countryResult1.CountryShort.ShouldNotBe(countryResult2.CountryShort);
                countryResult1.IsActive.ShouldNotBe(countryResult2.IsActive);
            });
        }
    }
}
