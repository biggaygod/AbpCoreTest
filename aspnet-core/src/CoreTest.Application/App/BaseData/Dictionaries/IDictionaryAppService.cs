using Abp.Application.Services;
using CoreTest.App.BaseData.Dictionaries.Dto;
using CoreTest.BaseDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreTest.App.BaseData.Dictionaries
{
    public interface IDictionaryAppService : IAsyncCrudAppService<DictionaryDto, int, PageResultRequestSearch, CreateDictionaryDto, DictionaryDto>,IApplicationService
    {
    }
}
