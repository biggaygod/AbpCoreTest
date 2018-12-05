using Abp.AutoMapper;
using CoreTest.Entities.Customer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoreTest.App.Customers.Dto
{
    [AutoMapTo(typeof(CustomerBrand))]
    public class CreateCustomerBrandDto
    {
        public int? Id { get; set; }

        [MaxLength(20, ErrorMessage = "MaxLength 20")]
        public string CountryCode { get; set; }

        public string CountryName { get; set; }

        public int? BrandId { get; set; }

        public int? CustomerId { get; set; }
    }
}
