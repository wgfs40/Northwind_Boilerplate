using System.Collections.Generic;
using Wind.Northwind.Permissions.Dto;

namespace Wind.Northwind.Web.Models.Roles
{
    public interface IPermissionsEditViewModel
    {
        List<PermissionListDto> Permissions { get; set; }

        List<string> GrantedPermissionNames { get; set; }
    }
}
