using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wind.Northwind.Roles.Dto;

namespace Wind.Northwind.Permissions.Dto
{
    public class GetRoleForEditOutput
    {
        public RoleEditDto Role { get; set; }

        public List<PermissionListDto> Permissions { get; set; }

        public List<string> GrantedPermissionNames { get; set; }
    }
}
