using Abp.AutoMapper;
using CoreTest.Entities.Customer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoreTest.App.Customers.Dto
{
    [AutoMapTo(typeof(Customer))]
    public class CreateCustomerDto
    {
        public int? Id { get; set; }

        public string CustomerCode { get; set; }

        [MaxLength(120, ErrorMessage = "MaxLength 120")]
        public string CustomerName { get; set; }

        [MaxLength(2000, ErrorMessage = "MaxLength 2000")]
        public virtual string Address { get; set; }

        [MaxLength(120, ErrorMessage = "MaxLength 120")]
        public virtual string Phone { get; set; }

        public int? SyncId { get; set; }

        public string EngName { get; set; }

        public string Spell { get; set; }

        public bool IsActive { get; set; }
    }
}
