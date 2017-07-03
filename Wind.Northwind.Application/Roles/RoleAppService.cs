using System;
using System.Linq;
using System.Threading.Tasks;
using Abp.Authorization;
using Wind.Northwind.Authorization.Roles;
using Wind.Northwind.Roles.Dto;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using System.Collections.Generic;
using Abp.AutoMapper;

namespace Wind.Northwind.Roles
{
    /* THIS IS JUST A SAMPLE. */
    public class RoleAppService : NorthwindAppServiceBase,IRoleAppService
    {
        private readonly RoleManager _roleManager;
        private readonly IPermissionManager _permissionManager;
        private readonly IRepository<Role, int> _roleRepository;

        public RoleAppService(RoleManager roleManager, IPermissionManager permissionManager, IRepository<Role, int> roleRepository)
        {
            _roleManager = roleManager;
            _permissionManager = permissionManager;
            _roleRepository = roleRepository;
        }

        public async Task UpdateRolePermissions(UpdateRolePermissionsInput input)
        {
            var role = await _roleManager.GetRoleByIdAsync(input.RoleId);
            
            var grantedPermissions = _permissionManager
                .GetAllPermissions()
                .Where(p => input.GrantedPermissionNames.Contains(p.Name))
                .ToList();

            await _roleManager.SetGrantedPermissionsAsync(role, grantedPermissions);
        }

        public PagedResultDto<RoleDto> GetRolesLists()
        {
            var count = _roleRepository.GetAll().Count();
            var listrole = _roleRepository.GetAll();
            

            return new PagedResultDto<RoleDto>(count, listrole.MapTo<List<RoleDto>>());
        }
    }
}