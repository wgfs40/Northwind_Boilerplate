using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace Wind.Northwind.Authorization
{
    public class NorthwindAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            //Common permissions
            var pages = context.GetPermissionOrNull(PermissionNames.Pages);
            if (pages == null)
            {
                pages = context.CreatePermission(PermissionNames.Pages, L("Pages"));
            }

            var users = pages.CreateChildPermission(PermissionNames.Pages_Users, L("Users"));
            users.CreateChildPermission(PermissionNames.Pages_User_Create, L("Create User"));
            users.CreateChildPermission(PermissionNames.Pages_User_Edit, L("User Edit"));

            //Host permissions
            var tenants = pages.CreateChildPermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, NorthwindConsts.LocalizationSourceName);
        }
    }
}
