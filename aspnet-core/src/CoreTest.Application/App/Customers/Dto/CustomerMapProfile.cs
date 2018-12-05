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

            CreateMap<Customer, CustomerDto>().ForMember(x => x.CountryName, opt => opt.Ignore()); ;

            CreateMap<CreateBrandDto, Customer>();

            CreateMap<CustomerBrand, CustomerBrandDto>().ForMember(x => x.CountryName, opt => opt.Ignore());

            CreateMap<CustomerContact, CustomerContactDto>().ForMember(x => x.CountryName, opt => opt.Ignore()); ;

            CreateMap<CustomerFile, CustomerFileDto>().ForMember(x => x.CountryName, opt => opt.Ignore()); ;
        }
    }
}
