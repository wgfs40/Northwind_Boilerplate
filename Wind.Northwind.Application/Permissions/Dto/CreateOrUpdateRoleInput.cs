using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Wind.Northwind.Roles.Dto;

namespace Wind.Northwind.Permissions.Dto
{
    public class CreateOrUpdateRoleInput
    {
        [Required]
        public RoleEditDto Role { get; set; }

        [Required]
        public List<string> GrantedPermissionNames { get; set; }
    }
}
