using Abp.AutoMapper;
using CoreTest.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreTest.Brands.Dto
{
    [AutoMapTo(typeof(Brand))]
    public class CreateBrandDto
    {
        public int? Id { get; set; }

        public string CountryCode { get; set; }

        public string CountryName { get; set; }

        public string BrandName { get; set; }

        public string EngName { get; set; }

        public string Spell { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreationTime { get; set; }

        public long? CreatorUserId { get; set; }

        public DateTime? LastModificationTime { get; set; }

        public long? LastModifierUserId { get; set; }

        public bool IsDeleted { get; set; }
    }
}
