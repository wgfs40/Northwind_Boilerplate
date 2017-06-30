using System.Threading.Tasks;
using Abp.Application.Services;
using Wind.Northwind.Roles.Dto;

namespace Wind.Northwind.Roles
{
    public interface IRoleAppService : IApplicationService
    {
        Task UpdateRolePermissions(UpdateRolePermissionsInput input);
    }
}
