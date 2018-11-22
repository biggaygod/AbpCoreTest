using AutoMapper;
using CoreTest.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreTest.Brands.Dto
{
    public class BrandMapProfile :Profile
    {
        public BrandMapProfile()
        {
            CreateMap<Brand, BrandDto>();
            CreateMap<Brand, CreateBrandDto>().ForMember(x => x.CountryName, opt => opt.Ignore());
        }
    }
}
