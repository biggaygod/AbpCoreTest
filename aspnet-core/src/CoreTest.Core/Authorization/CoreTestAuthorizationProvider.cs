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
            //基础数据权限添加
            context.CreatePermission(PermissionNames.Pages_Brands, L("Brands"));
            context.CreatePermission(PermissionNames.Pages_Countrys, L("Countrys"));
            context.CreatePermission(PermissionNames.Pages_Customers, L("Customers"));
            context.CreatePermission(PermissionNames.Pages_SignBodies, L("SignBodies"));
            context.CreatePermission(PermissionNames.Pages_Dictionaries, L("Dictionaries"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, CoreTestConsts.LocalizationSourceName);
        }
    }
}
