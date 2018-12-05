using Abp.AutoMapper;
using CoreTest.Entities.Customer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoreTest.App.Customers.Dto
{
    [AutoMapTo(typeof(CustomerContact))]
    public class CreateCustomerContactDto
    {
        public int? Id { get; set; }

        [MaxLength(20, ErrorMessage = "MaxLength 20")]
        public string CountryCode { get; set; }

        public string CountryName { get; set; }

        public int? CustomerId { get; set; }

        public string ContactName { get; set; }

        public string Address { get; set; }

        public string Position { get; set; }

        public string TelePhone { get; set; }

        public string Email { get; set; }
    }
}
