using CoreTest.EntityFrameworkCore;
using CoreTest.Tests.Brands;
using CoreTest.Tests.Countrys;
using CoreTest.Tests.Customers;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreTest.Tests.TestDatas
{
    public class TestDaraBuilder
    {
        private CoreTestDbContext _context;
        private readonly int _tenantId;

        public TestDaraBuilder(CoreTestDbContext context, int tenantId)
        {
            _context = context;
            _tenantId = tenantId;
        }

        public void Create()
        {
            //_context.DisableAllFilters();

            new TestBrandBuilder(_context, _tenantId).Create();
            new TestCountryBuilder(_context, _tenantId).Create();
            new TestCustomerBuilder(_context, _tenantId).Create();

            _context.SaveChanges();
        }
    }
}
