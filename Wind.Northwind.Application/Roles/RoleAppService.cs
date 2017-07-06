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
using Wind.Northwind.Permissions.Dto;
using System.Diagnostics;
using Wind.Northwind.Permissions;

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

        public async Task<GetRoleForEditOutput> GetGetRoleForEdit(NullableIdDto input)
        {
            var permissions = PermissionManager.GetAllPermissions();
            var grandPermission = new Permission[0];
            RoleEditDto roleEditdto;

            if (input.Id.HasValue) //Existing role
            {
                var role = await _roleManager.GetRoleByIdAsync(input.Id.Value);
                grandPermission = (await _roleManager.GetGrantedPermissionsAsync(role)).ToArray();

                roleEditdto = role.MapTo<RoleEditDto>();
            }
            else
            {
                roleEditdto = new RoleEditDto();
            }

            return new GetRoleForEditOutput {
                Role = roleEditdto,
                Permissions = permissions.MapTo<List<PermissionListDto>>().OrderBy(p => p.DisplayName).ToList(),
                GrantedPermissionNames = grandPermission.Select(p => p.Name).ToList()
            };
        }

        public async Task CreateOrUpdateRole(CreateOrUpdateRoleInput input)
        {
            if (input.Role.Id.HasValue)
            {
                await UpdateRoleAsync(input);
            }
            else
            {
                await CreateRoleAsync(input);
            }
        }
        

        public async Task DeleteRole(EntityDto input)
        {
            var role = await _roleManager.GetRoleByIdAsync(input.Id);
            CheckErrors(await _roleManager.DeleteAsync(role));
        }

        #region metodos privados
        private async Task CreateRoleAsync(CreateOrUpdateRoleInput input)
        {
            var role = new Role(AbpSession.TenantId, input.Role.DisplayName) { IsDefault = input.Role.IsDefault };
            CheckErrors(await _roleManager.CreateAsync(role));
            await CurrentUnitOfWork.SaveChangesAsync(); //It's done to get Id of the role.
            await UpdateGrantedPermissionsAsync(role, input.GrantedPermissionNames);
        }

        private async Task UpdateGrantedPermissionsAsync(Role role, List<string> grantedPermissionNames)
        {
            var grantedPermissions = PermissionManager.GetPermissionsFromNamesByValidating(grantedPermissionNames);
            await _roleManager.SetGrantedPermissionsAsync(role, grantedPermissions);
        }

        #endregion

        #region metodos protected
        protected virtual async Task UpdateRoleAsync(CreateOrUpdateRoleInput input)
        {
            Debug.Assert(input.Role.Id != null, "input.Role.Id should be set.");

            var role = await _roleManager.GetRoleByIdAsync(input.Role.Id.Value);
            role.DisplayName = input.Role.DisplayName;
            role.IsDefault = input.Role.IsDefault;

            await UpdateGrantedPermissionsAsync(role, input.GrantedPermissionNames);
        }

        #endregion

    }
}