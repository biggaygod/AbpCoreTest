using CoreTest.Entities.Customer;
using CoreTest.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreTest.Tests.Brands
{
    public class TestBrandBuilder
    {
        private CoreTestDbContext _context;
        private readonly int _tenantId;

        public TestBrandBuilder(CoreTestDbContext context, int tenantId)
        {
            _context = context;
            _tenantId = tenantId;
        }
        public void Create()
        {
            for (int i = 0; i < 8; i++)
            {
                var brand = new Brand()
                {
                    BrandName = "测试品牌"+i,
                    EngName = "TestBrand"+i,
                    Spell = "Test"+i,
                    IsActive = true,
                };
                _context.Brand.Add(brand);
            }
        }
    }
}
