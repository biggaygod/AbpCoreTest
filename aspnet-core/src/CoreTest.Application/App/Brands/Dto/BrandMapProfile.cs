using AutoMapper;
using CoreTest.Entities.Customer;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreTest.Brands.Dto
{
    public class BrandMapProfile :Profile
    {
        public BrandMapProfile()
        {
            CreateMap<BrandDto, Brand>().ForMember(x => x.DeleterUserId, opt => opt.Ignore())
                .ForMember(x => x.DeletionTime, opt => opt.Ignore());

            CreateMap<Brand, BrandDto>().ForMember(x => x.CountryName, opt => opt.Ignore()); ;

            CreateMap<CreateBrandDto, Brand>();
        }
    }
}
