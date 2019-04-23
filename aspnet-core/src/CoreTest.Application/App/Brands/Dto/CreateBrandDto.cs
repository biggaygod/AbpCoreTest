using Abp.AutoMapper;
using CoreTest.Entities.Customer;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreTest.Brands.Dto
{
    [AutoMapTo(typeof(Brand))]
    public class CreateBrandDto
    {
        public int? Id { get; set; }

        public string BrandName { get; set; }

        public string EngName { get; set; }

        public string Spell { get; set; }

        public bool IsActive { get; set; }
    }
}
