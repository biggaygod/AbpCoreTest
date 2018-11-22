using Abp.EntityFrameworkCore;
using CoreTest.Entities;
using CoreTest.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreTest.EntityFrameworkCore.Repositories
{
    public class BrandRepository : CoreTestRepositoryBase<Brand,int>, IBrandRepository
    {
        public BrandRepository(IDbContextProvider<CoreTestDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
