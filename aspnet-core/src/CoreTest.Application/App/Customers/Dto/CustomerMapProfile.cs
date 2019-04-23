using AutoMapper;
using CoreTest.Brands.Dto;
using CoreTest.Entities.Customer;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreTest.App.Customers.Dto
{
    public class CustomerMapProfile:Profile
    {
        public CustomerMapProfile()
        {
            CreateMap<CustomerDto, Customer>();

            CreateMap<Customer, CustomerDto>();

            CreateMap<CreateBrandDto, Customer>();

            CreateMap<CustomerBrand, CustomerBrandDto>();

            CreateMap<CustomerContact, CustomerContactDto>();

            CreateMap<CustomerFile, CustomerFileDto>();
        }
    }
}
