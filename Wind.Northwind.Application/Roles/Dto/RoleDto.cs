using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Abp.AutoMapper;
using Wind.Northwind.Authorization.Roles;

namespace Wind.Northwind.Roles.Dto
    
{
    [AutoMapFrom(typeof(Role))]
    public class RoleDto : EntityDto<int>
    {
        public string DisplayName { get; set; }
    }
}
