using Abp.Authorization;
using AssetManagement.Authorization.Roles;
using AssetManagement.Authorization.Users;

namespace AssetManagement.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
