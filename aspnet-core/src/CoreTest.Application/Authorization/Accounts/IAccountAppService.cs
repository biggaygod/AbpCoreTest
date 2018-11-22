﻿using System.Threading.Tasks;
using Abp.Application.Services;
using CoreTest.Authorization.Accounts.Dto;

namespace CoreTest.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
