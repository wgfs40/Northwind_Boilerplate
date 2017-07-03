using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Wind.Northwind.Users.Dto;
using System.Collections.Generic;
using Wind.Northwind.Authorization.Roles;

namespace Wind.Northwind.Users
{
    public interface IUserAppService : IApplicationService
    {
        Task ProhibitPermission(ProhibitPermissionInput input);

        Task RemoveFromRole(long userId, string roleName);

        Task<ListResultDto<Role>> GetRolesList();

        Task<ListResultDto<UserListDto>> GetUsers();

        List<UserListDto> GetUsersList();


        Task CreateUser(CreateUserInput input);

        PagedResultDto<UserListDto> UserAll(GetUsersInput input);
    }
}