using Abp.AutoMapper;
using CoreTest.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreTest.App.Countrys.Dto
{
    [AutoMapTo(typeof(Country))]
    public class CreateCountryDto
    {
        public virtual string CountryCode { get; set; }

        public virtual string CountryName { get; set; }

        public virtual string CountryShort { get; set; }

        public virtual string ChineseName { get; set; }

        public virtual string EnglishName { get; set; }

        public virtual bool IsActive { get; set; }
    }
}
