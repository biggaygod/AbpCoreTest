using Abp.Authorization;
using CoreTest.Authorization.Roles;
using CoreTest.Authorization.Users;

namespace CoreTest.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
