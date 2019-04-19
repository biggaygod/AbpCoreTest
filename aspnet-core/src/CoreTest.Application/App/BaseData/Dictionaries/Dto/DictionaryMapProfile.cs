using AutoMapper;
using CoreTest.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreTest.App.BaseData.Dictionaries.Dto
{
    public class DictionaryMapProfile : Profile
    {
        public DictionaryMapProfile()
        {
            CreateMap<DictionaryDto, Dictionary>();

            CreateMap<Dictionary, DictionaryDto>();

            CreateMap<CreateDictionaryDto, Dictionary>();
        }
    }
}
