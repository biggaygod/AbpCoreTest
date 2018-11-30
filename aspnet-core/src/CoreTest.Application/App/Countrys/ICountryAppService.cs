using Abp.Application.Services;
using CoreTest.App.Countrys.Dto;
using CoreTest.BaseDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreTest.App.Countrys
{
    public interface ICountryAppService:IAsyncCrudAppService<CountryDto, int, PageResultRequestSearch, CreateCountryDto, CountryDto>,IApplicationService
    {
    }
}
