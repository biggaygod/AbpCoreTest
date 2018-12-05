using CoreTest.App.Customers;
using CoreTest.App.Customers.Dto;
using CoreTest.BaseDto;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CoreTest.Tests.Customer
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
            // Act
            var output = await _CustomerAppService.GetAll(new PageResultRequestSearch { MaxResultCount = 20, SkipCount = 0, where = null, Sorting = null });

            // Assert
            output.Items.Count.ShouldBeGreaterThan(0);
        }

        [Fact]
        public async Task CreateCustomer_Test()
        {
            // Act
            await _CustomerAppService.Create(
                new CreateCustomerDto
                {
                    CustomerCode = "TestCN",
                    IsActive = true,
                    CustomerName = "中国测试",
                    CountryCode = "CN",
                    Address="中国上海",
                    Phone="17796554433",
                    Spell="AA",
                    SyncId=1
                });

            await UsingDbContextAsync(async context =>
            {
                var johnNashCustomer = await context.Customer.FirstOrDefaultAsync(u => u.CustomerCode == "TestCN");
                johnNashCustomer.ShouldNotBeNull();
            });
        }
    }
}
