using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using CoreTest.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoreTest.App.Countrys.Dto
{
    [AutoMapTo(typeof(Country))]
    public class CountryDto: EntityDto<int>
    {
        [MaxLength(20, ErrorMessage = "MaxLength 20")]
        public virtual string CountryCode { get; set; }

        [MaxLength(120, ErrorMessage = "MaxLength 120")]
        public virtual string CountryName { get; set; }

        [MaxLength(120, ErrorMessage = "MaxLength 120")]
        public virtual string CountryShort { get; set; }

        [MaxLength(120, ErrorMessage = "MaxLength 120")]
        public virtual string ChineseName { get; set; }

        [MaxLength(120, ErrorMessage = "MaxLength 120")]
        public virtual string EnglishName { get; set; }

        public virtual int? TenantId { get; set; }

        public virtual bool IsActive { get; set; }

        public DateTime CreationTime { get; set; }

        public long? CreatorUserId { get; set; }

        public DateTime? LastModificationTime { get; set; }

        public long? LastModifierUserId { get; set; }

        public bool IsDeleted { get; set; }
    }
}
