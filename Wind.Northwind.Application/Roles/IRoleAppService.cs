using System.Threading.Tasks;
using Abp.Application.Services;
using Wind.Northwind.Roles.Dto;
using Abp.Application.Services.Dto;
using Wind.Northwind.Permissions.Dto;

namespace Wind.Northwind.Roles
{
    public interface IRoleAppService : IApplicationService
    {
        Task UpdateRolePermissions(UpdateRolePermissionsInput input);

        Task<GetRoleForEditOutput> GetGetRoleForEdit(NullableIdDto input);

        Task CreateOrUpdateRole(CreateOrUpdateRoleInput input);

        Task DeleteRole(EntityDto input);

        PagedResultDto<RoleListDto> GetRolesLists();
    }
}
