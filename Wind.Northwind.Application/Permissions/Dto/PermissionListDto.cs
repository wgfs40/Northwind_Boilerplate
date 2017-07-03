﻿using Abp.AutoMapper;

namespace Wind.Northwind.Permissions.Dto
{
    [AutoMapFrom(typeof(Abp.Authorization.Permission))]
    public class PermissionListDto
    {
        public string ParentName { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string Description { get; set; }

        public bool IsGrantedByDefault { get; set; }
    }
}
