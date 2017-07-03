using System.Threading.Tasks;
using Abp.Application.Services;
using Wind.Northwind.Roles.Dto;
using Abp.Application.Services.Dto;

namespace Wind.Northwind.Roles
{
    public interface IRoleAppService : IApplicationService
    {
        Task UpdateRolePermissions(UpdateRolePermissionsInput input);
        
        PagedResultDto<RoleDto> GetRolesLists();
    }
}
