using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace CoreTest.Controllers
{
    public abstract class CoreTestControllerBase: AbpController
    {
        protected CoreTestControllerBase()
        {
            LocalizationSourceName = CoreTestConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
