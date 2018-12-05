using Abp.Application.Services;
using CoreTest.App.Customers.Dto;
using CoreTest.BaseDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreTest.App.Customers
{
    public interface ICustomerContactAppService: IAsyncCrudAppService<CustomerContactDto, int, PageResultRequestSearch, CreateCustomerContactDto, CustomerContactDto>, IApplicationService
    {
    }
}
