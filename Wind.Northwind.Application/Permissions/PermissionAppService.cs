﻿using System;
using System.Linq;
using Abp.Application.Services.Dto;
using Wind.Northwind.Permissions.Dto;
using System.Collections.Generic;
using Abp.Authorization;
using Abp.AutoMapper;

namespace Wind.Northwind.Permissions
{
    public class PermissionAppService : NorthwindAppServiceBase, IPermissionAppService
    {
        public ListResultDto<PermissionListDto> GetListPermission()
        {
            var permissions = PermissionManager.GetAllPermissions();
            var rootPermissions = permissions.Where(p => p.Parent == null);

            var result = new List<FlatPermissionWithLevelDto>();

            foreach (var rootPermission in rootPermissions)
            {
                var level = 0;
                AddPermission(rootPermission,permissions,result,level);

            }

            return new ListResultDto<PermissionListDto>
            {
                Items = result
            };
        }

        private void AddPermission(Permission permission, IReadOnlyList<Permission>allpermissions,List<FlatPermissionWithLevelDto>result,int level)
        {
            var flatPermission = permission.MapTo<FlatPermissionWithLevelDto>();
            flatPermission.Level = level;

            if (permission.Children == null)
            {
                return;
            }

            var Children = allpermissions.Where(p => p.Parent != null && p.Parent.Name == permission.Name).ToList();
            foreach (var chilPermission in Children)
            {
                AddPermission(chilPermission,allpermissions,result,level + 1);
            }
        }
    }
}
