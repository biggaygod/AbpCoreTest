﻿using Abp.AutoMapper;
using CoreTest.Entities.Customer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoreTest.App.Customers.Dto
{
    [AutoMapTo(typeof(CustomerFile))]
    public class CreateCustomerFileDto
    {
        public int? Id { get; set; }

        public int CustomerId { get; set; }

        public string FilePath { get; set; }

        public string FileName { get; set; }
    }
}
