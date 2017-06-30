using Abp.Authorization;
using Wind.Northwind.Authorization.Roles;
using Wind.Northwind.MultiTenancy;
using Wind.Northwind.Users;

namespace Wind.Northwind.Authorization
{
    public class PermissionChecker : PermissionChecker<Tenant, Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
