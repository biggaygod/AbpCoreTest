using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using CoreTest.Entities.Customer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoreTest.App.Customers.Dto
{
    [AutoMapTo(typeof(CustomerFile))]
    public class CustomerFileDto : EntityDto<int>
    {
        [MaxLength(20, ErrorMessage = "MaxLength 20")]
        public string CountryCode { get; set; }

        public string CountryName { get; set; }

        public int CustomerId { get; set; }

        public string FilePath { get; set; }

        public string FileName { get; set; }

        public DateTime CreationTime { get; set; }

        public long? CreatorUserId { get; set; }

        public DateTime? LastModificationTime { get; set; }

        public long? LastModifierUserId { get; set; }

        public bool IsDeleted { get; set; }

        public int? TenantId { get; set; }
    }
}
