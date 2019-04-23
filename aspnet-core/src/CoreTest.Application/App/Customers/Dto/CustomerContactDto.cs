using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using CoreTest.Entities.Customer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoreTest.App.Customers.Dto
{
    [AutoMapTo(typeof(CustomerContact))]
    public class CustomerContactDto : EntityDto<int>
    {
        public int CustomerId { get; set; }

        public string ContactName { get; set; }

        public string Address { get; set; }

        public string Position { get; set; }

        public string TelePhone { get; set; }

        public string Email { get; set; }

        public DateTime CreationTime { get; set; }

        public long? CreatorUserId { get; set; }

        public DateTime? LastModificationTime { get; set; }

        public long? LastModifierUserId { get; set; }

        public bool IsDeleted { get; set; }

        public int? TenantId { get; set; }
    }
}
