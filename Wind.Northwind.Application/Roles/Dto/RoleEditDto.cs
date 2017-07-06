using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;
using Wind.Northwind.Authorization.Roles;

namespace Wind.Northwind.Roles.Dto
{
    [AutoMap(typeof(Role))]
    public class RoleEditDto
    {
        public int? Id { get; set; }

        [Required]
        public string DisplayName { get; set; }

        public bool IsDefault { get; set; }
    }
}
