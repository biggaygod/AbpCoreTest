using Abp.Domain.Repositories;
using CoreTest.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreTest.IRepositories
{
    public interface IBrandRepository : IRepository<Brand,int>
    {
    }
}
