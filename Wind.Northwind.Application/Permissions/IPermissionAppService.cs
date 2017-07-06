using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Threading.Tasks;
using Wind.Northwind.Permissions.Dto;

namespace Wind.Northwind.Permissions
{
    public interface IPermissionAppService : IApplicationService
    {
        ListResultDto<FlatPermissionWithLevelDto> GetListPermission();

    }
}
