using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Wind.Northwind.Authorization.Roles;

namespace Wind.Northwind.Roles.Dto

{
    [AutoMapFrom(typeof(Role))]
    public class RoleDto : EntityDto<int>
    {
        public string DisplayName { get; set; }
        public bool IsStatic { get; set; }
        public bool IsDefault { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }

    }
}
