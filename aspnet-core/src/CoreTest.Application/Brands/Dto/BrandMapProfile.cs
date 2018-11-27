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
            CreateMap<BrandDto, Brand>();

            CreateMap<Brand, BrandDto>().ForMember(x => x.CountryName, opt => opt.Ignore());

            CreateMap<CreateBrandDto, Brand>();
        }
    }
}
