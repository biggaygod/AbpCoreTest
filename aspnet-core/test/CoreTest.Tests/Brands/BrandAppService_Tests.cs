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
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using CoreTest.Entities.Customer;
using CoreTest.Authorization.Users;
using CoreTest.MultiTenancy;

namespace CoreTest.Tests.Brands
{
    public class BrandAppService_Tests: CoreTestTestBase
    {
        private readonly IBrandAppService _brandAppService;

        public BrandAppService_Tests()
        {
            _brandAppService = LocalIocManager.Resolve<IBrandAppService>();
        }

        [Fact]
        public async Task CreateBrand_Test()
        {
            //LoginAsTenant(Tenant.DefaultTenantName, "TestUser");
            //var adminUser = UsingDbContext(ctx => ctx.Users.FirstOrDefault(u => u.UserName == User.AdminUserName));
           
            await UsingDbContextAsync(async context =>
            {
                var intialCount = context.Brand.Count();
                var brand = await _brandAppService.Create(
                new CreateBrandDto
                {
                    CountryCode = "CN",
                    BrandName = "测试品牌",
                    EngName = "TestBrand",
                    Spell = "Test",
                    IsActive = true,
                });
                var johnNashUser = await context.Brand.FirstOrDefaultAsync(u => u.Id == brand.Id);
                context.Brand.Count().ShouldBe(intialCount + 1);
                johnNashUser.ShouldNotBeNull();
            });
        }

        [Fact]
        public void DeleteBrand_Test()
        {
            UsingDbContextAsync(async context =>
            {
                var defaultBrand = await context.Brand.FirstOrDefaultAsync();
                await _brandAppService.Delete(new EntityDto<int>() {
                    Id = defaultBrand.Id
                });
                var brand = context.Brand.FirstOrDefault(u => u.Id == defaultBrand.Id);
                brand.ShouldBeNull();
            });
        }

        [Fact]
        public void UpdateBrands_Test()
        {
            UsingDbContext(async ctx =>
            {
                //Arrange 
                var Brand = new CreateBrandDto
                {
                    CountryCode = "CNS",
                    BrandName = "测试品牌S",
                    EngName = "TestBrandS",
                    Spell = "TestS",
                    IsActive = true,
                };
                // Act
                var brandResult1 =await _brandAppService.Create(Brand);
               
                var brandResult2 =await _brandAppService.Update(brandResult1);

                //Assert            
                brandResult1.ShouldNotBe(null);
                brandResult2.ShouldNotBe(null);
                brandResult1.Id.ShouldBe(brandResult2.Id);
                brandResult1.CountryCode.ShouldBe(brandResult2.CountryCode);
                brandResult1.BrandName.ShouldNotBe(brandResult2.BrandName);
                brandResult1.EngName.ShouldNotBe(brandResult2.EngName);
                brandResult1.Spell.ShouldNotBe(brandResult2.Spell);
                brandResult1.IsActive.ShouldNotBe(brandResult2.IsActive);
            });            
        }

        [Fact]
        public void GetBrands_Test()
        {          
            UsingDbContext(async ctx =>
            {
                var initalCount = ctx.Brand.Count();
                //Arrange
                var Brand1 = new CreateBrandDto
                {
                    CountryCode = "CNS",
                    BrandName = "测试品牌S",
                    EngName = "TestBrandS",
                    Spell = "TestS",
                    IsActive = true,
                };

                var Brand2 = new CreateBrandDto
                {
                    CountryCode = "CNF",
                    BrandName = "测试品牌F",
                    EngName = "TestBrandF",
                    Spell = "TestF",
                    IsActive = true,
                };
                initalCount.ShouldBe(8);
                //Act
                var brandResult1 =await _brandAppService.Create(Brand1);
                var brandResult2 =await _brandAppService.Create(Brand2);
                //Assert
                initalCount.ShouldBe(8);
                brandResult1.Id.ShouldBeGreaterThan(7);
                brandResult2.Id.ShouldBeGreaterThan(8);
                ctx.Brand.Count().ShouldBe(initalCount + 2);
                ctx.Brand.FirstOrDefault(t => t.CountryCode == "CNS").ShouldNotBe(null);
                var task = ctx.Brand.FirstOrDefault(t => t.CountryCode == "CNS");
                task.ShouldNotBe(null);
                task.IsActive.ShouldBe(true);
            });
        }
    }
}
