using Abp.Application.Services.Dto;
using CoreTest.App.BaseData.Dictionaries;
using CoreTest.App.BaseData.Dictionaries.Dto;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CoreTest.Tests.BaseData.Dictionaries
{
    public class DictionaryAppService_Tests:CoreTestTestBase
    {
        private readonly IDictionaryAppService _dictionaryAppService;

        public DictionaryAppService_Tests()
        {
            _dictionaryAppService = LocalIocManager.Resolve<IDictionaryAppService>();
        }

        [Fact]
        public async Task CreateDictionary_Test()
        {
            //LoginAsTenant(Tenant.DefaultTenantName, "TestUser");
            //var adminUser = UsingDbContext(ctx => ctx.Users.FirstOrDefault(u => u.UserName == User.AdminUserName));

            await UsingDbContextAsync(async context =>
            {
                var intialCount = context.Dictionary.Count();
                var Dictionary = await _dictionaryAppService.Create(
                new CreateDictionaryDto
                {
                   DicName="字典测试",
                   Description="字典测试描述",
                });
                var johnNashUser = await context.Dictionary.FirstOrDefaultAsync(u => u.Id == Dictionary.Id);
                context.Dictionary.Count().ShouldBe(intialCount + 1);
                johnNashUser.ShouldNotBeNull();
            });
        }

        [Fact]
        public void DeleteDictionary_Test()
        {
            UsingDbContextAsync(async context =>
            {
                var defaultDictionary = await context.Dictionary.FirstOrDefaultAsync();
                await _dictionaryAppService.Delete(new EntityDto<int>()
                {
                    Id = defaultDictionary.Id
                });
                var Dictionary = context.Dictionary.FirstOrDefault(u => u.Id == defaultDictionary.Id);
                Dictionary.ShouldBeNull();
            });
        }

        [Fact]
        public void UpdateDictionarys_Test()
        {
            UsingDbContext(async ctx =>
            {
                //Arrange 
                var Dictionary = new CreateDictionaryDto
                {
                    DicName = "字典测试",
                    Description = "字典测试描述",
                };
                // Act
                var DictionaryResult1 = await _dictionaryAppService.Create(Dictionary);

                var DictionaryResult2 = await _dictionaryAppService.Update(DictionaryResult1);

                //Assert            
                DictionaryResult1.ShouldNotBe(null);
                DictionaryResult2.ShouldNotBe(null);
                DictionaryResult1.Id.ShouldBe(DictionaryResult2.Id);
                DictionaryResult1.DicName.ShouldBe(DictionaryResult2.DicName);
                DictionaryResult1.Description.ShouldNotBe(DictionaryResult2.Description);
            });
        }

        [Fact]
        public void GetDictionarys_Test()
        {
            UsingDbContext(async ctx =>
            {
                var initalCount = ctx.Dictionary.Count();
                //Arrange
                var Dictionary1 = new CreateDictionaryDto
                {
                    DicName = "字典测试A",
                    Description = "字典测试描述A",
                };

                var Dictionary2 = new CreateDictionaryDto
                {
                    DicName = "字典测试B",
                    Description = "字典测试描述B",
                };
                initalCount.ShouldBe(8);
                //Act
                var DictionaryResult1 = await _dictionaryAppService.Create(Dictionary1);
                var DictionaryResult2 = await _dictionaryAppService.Create(Dictionary2);
                //Assert
                initalCount.ShouldBe(8);
                DictionaryResult1.Id.ShouldBeGreaterThan(7);
                DictionaryResult2.Id.ShouldBeGreaterThan(8);
                ctx.Dictionary.Count().ShouldBe(initalCount + 2);
                ctx.Dictionary.FirstOrDefault(t => t.DicName == "字典测试A").ShouldNotBe(null);
            });
        }
    }
}
