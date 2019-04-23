using Abp.Application.Services.Dto;
using CoreTest.App.Customers;
using CoreTest.App.Customers.Dto;
using CoreTest.BaseDto;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CoreTest.Tests.Customers
{
    public class CustomerAppService_Tests: CoreTestTestBase
    {
        private readonly ICustomerAppService _CustomerAppService;

        public CustomerAppService_Tests()
        {
            _CustomerAppService = Resolve<ICustomerAppService>();
        }

        [Fact]
        public async Task GetCustomers_Test()
        {
            await UsingDbContextAsync(async context =>
            {
                // Act
                await _CustomerAppService.Create(
                new CreateCustomerDto
                {
                    CustomerCode = "TestCN",
                    IsActive = true,
                    CustomerName = "中国测试",
                    Address = "中国上海",
                    Phone = "17796554433",
                    Spell = "AA",
                    SyncId = 1,
                    EngName = "ChinaTest"
                });           
                var johnNashCountry = await context.Customer.FirstOrDefaultAsync(u => u.CustomerCode == "TestCN");
                johnNashCountry.ShouldNotBeNull();
            });
        }

        [Fact]
        public async Task CreateCustomer_Test()
        {          
            await UsingDbContextAsync(async ctx =>
            {
                var initalCount = ctx.Customer.Count();
                var customerResult1 = await _CustomerAppService.Create(
                    new CreateCustomerDto
                    {
                        CustomerCode = "TestCN",
                        IsActive = true,
                        CustomerName = "中国测试",
                        Address = "中国上海",
                        Phone = "17796554433",
                        Spell = "AA",
                        SyncId = 1,
                        EngName = "ChinaTest"
                    });
                initalCount.ShouldBe(8);
                ctx.Customer.FirstOrDefault(t => t.CustomerCode == "TestCN").ShouldNotBeNull();
                ctx.Customer.Count().ShouldBe(initalCount + 1);
                customerResult1.Id.ShouldBeGreaterThan(0);
            });
        }

        [Fact]
        public void DeleteCustomer_Test()
        {
            UsingDbContextAsync(async context =>
            {
                var defaultCustomer = await context.Customer.FirstOrDefaultAsync();
                await _CustomerAppService.Delete(new EntityDto<int>()
                {
                    Id = defaultCustomer.Id
                });
                var customer = context.Customer.FirstOrDefault(u => u.Id == defaultCustomer.Id);
                customer.ShouldBeNull();
            });
        }

        [Fact]
        public void UpdateCustomer_Test()
        {
            UsingDbContext(async ctx =>
            {
                //Arrange 
                var Customer = new CreateCustomerDto
                {
                    CustomerCode = "TestCN",
                    IsActive = false,
                    CustomerName = "中国测试",
                    Address = "中国上海",
                    Phone = "17796554433",
                    Spell = "AA",
                    SyncId = 1,
                    EngName = "ChinaTest"
                };
                // Act
                var customerResult1 = await _CustomerAppService.Create(Customer);

                var customerResult2 = await _CustomerAppService.Update(customerResult1);

                //Assert            
                customerResult1.ShouldNotBe(null);
                customerResult2.ShouldNotBe(null);
                customerResult1.Id.ShouldBe(customerResult2.Id);
                customerResult1.CountryCode.ShouldBe(customerResult2.CountryCode);
                customerResult1.TenantId.ShouldNotBe(customerResult2.TenantId);
                customerResult1.TenantId.ShouldNotBe(customerResult2.TenantId);
                customerResult1.EngName.ShouldNotBe(customerResult2.EngName);
                customerResult1.Spell.ShouldNotBe(customerResult2.Spell);
                customerResult1.IsActive.ShouldNotBe(customerResult2.IsActive);
                customerResult1.Address.ShouldNotBe(customerResult2.Address);
                customerResult1.Phone.ShouldNotBe(customerResult2.Phone);
                customerResult1.Spell.ShouldNotBe(customerResult2.Spell);
                customerResult1.SyncId.ShouldNotBe(customerResult2.SyncId);
            });
        }     
    }
}
