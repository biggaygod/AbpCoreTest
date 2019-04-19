using CoreTest.Entities.Base;
using CoreTest.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreTest.Tests.BaseData.Dictionaries
{
    public class TestDictionaryBuilder
    {
        private CoreTestDbContext _context;
        private readonly int _tenantId;

        public TestDictionaryBuilder(CoreTestDbContext context, int tenantId)
        {
            _context = context;
            _tenantId = tenantId;
        }
        public void Create()
        {
            for (int i = 0; i < 8; i++)
            {
                var dictionary = new Dictionary()
                {
                    Id = i + 1,
                    DicName="字典数据"+i,
                    Description="字典描述"+i,
                    TenantId= _tenantId,
                };
                _context.Dictionary.Add(dictionary);
                var dictionaryDetail1 = new DictionaryDetail()
                {
                    DicId = i + 1,
                    NameLCode = "字典详情数据" + i,
                    Description = "字典详情描述" + i,
                    TenantId = _tenantId,
                };
                var dictionaryDetail2 = new DictionaryDetail()
                {
                    DicId = i + 1,
                    NameLCode = "字典详情数据多" + i,
                    Description = "字典详情描述多" + i,
                    TenantId = _tenantId,
                };
                _context.DictionaryDetail.Add(dictionaryDetail1);
                _context.DictionaryDetail.Add(dictionaryDetail2);
            }
        }
    }
}
