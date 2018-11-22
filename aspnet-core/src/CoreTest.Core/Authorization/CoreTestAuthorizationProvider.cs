using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace CoreTest.Authorization
{
    public class CoreTestAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
            context.CreatePermission(PermissionNames.Pages_Brands, L("Brands"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, CoreTestConsts.LocalizationSourceName);
        }
    }
}
