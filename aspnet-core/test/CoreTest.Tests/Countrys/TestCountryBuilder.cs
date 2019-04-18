using CoreTest.Entities.Base;
using CoreTest.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreTest.Tests.Countrys
{
    public class TestCountryBuilder
    {
        private CoreTestDbContext _context;
        private readonly int _tenantId;

        public TestCountryBuilder(CoreTestDbContext context, int tenantId)
        {
            _context = context;
            _tenantId = tenantId;
        }
        public void Create()
        {
            for (int i = 0; i < 8; i++)
            {
                var country = new Country()
                {
                    Id = i + 1,
                    CountryCode = "TestCN" + i,
                    IsActive = true,
                    CountryName = "中国测试" + i,
                    CountryShort = "TestCN" + i,
                    EnglishName = "TestChina+i"
                };
                _context.Country.Add(country);
            }
        }
    }
}
