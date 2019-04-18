using CoreTest.Entities.Customer;
using CoreTest.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreTest.Tests.Customers
{
    public class TestCustomerBuilder
    {
        private CoreTestDbContext _context;
        private readonly int _tenantId;

        public TestCustomerBuilder(CoreTestDbContext context, int tenantId)
        {
            _context = context;
            _tenantId = tenantId;
        }
        public void Create()
        {
            for (int i = 0; i < 8; i++)
            {
                var customer = new Customer()
                {
                    Id = i + 1,
                    CustomerCode = "TestCN" + i,
                    IsActive = true,
                    CustomerName = "中国测试" + i,
                    CountryCode = "CN" + i,
                    Address = "中国上海" + i,
                    Phone = "17796554433" + i,
                    Spell = "AA" + i,
                    SyncId = 1 + i,
                    EngName = "ChinaTest" + i
                };
                _context.Customer.Add(customer);
            }
        }
    }
}
