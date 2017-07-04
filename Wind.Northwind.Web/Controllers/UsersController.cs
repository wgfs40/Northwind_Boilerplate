using System.Threading.Tasks;
using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;
using Wind.Northwind.Authorization;
using Wind.Northwind.Users;
using System.Collections.Generic;
using Wind.Northwind.Users.Dto;
using Abp.Application.Services.Dto;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Wind.Northwind.Web.Models.Users;
using Abp.Authorization;
using Wind.Northwind.Roles;
using Wind.Northwind.Permissions;

namespace Wind.Northwind.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Users)]
    public class UsersController : NorthwindControllerBase
    {
        private readonly IUserAppService _userAppService;
        private readonly IRoleAppService _roleAppService;
        private readonly IPermissionAppService _permissionAppService;

        public UsersController(IUserAppService userAppService, IRoleAppService roleAppService, IPermissionAppService permissionAppService)
        {
            _userAppService = userAppService;
            _roleAppService = roleAppService;
            _permissionAppService = permissionAppService;
        }

        [AbpAuthorize]
        public async Task<ActionResult> Index()
        {
            //var output = await _userAppService.GetUsers();
            var model = new UsersViewModel
            {
                FilterText = Request.QueryString["filterText"]
               
            };
            return View(model);
        }

        
        public async Task<PagedResultDto<UserListDto>> UserAll()
        {
            var listuser = await _userAppService.GetUsers();


            return new PagedResultDto<UserListDto>(listuser.Items.Count,listuser.Items);

            //var camelCaseFormatter = new JsonSerializerSettings();
            //camelCaseFormatter.ContractResolver = new CamelCasePropertyNamesContractResolver();
            //return Json(new {
            //    Result = "OK",
            //    Records = JsonConvert.SerializeObject(listuser.Items, camelCaseFormatter),
            //    TotalRecordCount = listuser.Items.Count
            //});

            //return Json(listuser,JsonRequestBehavior.AllowGet);
        }
    }
}