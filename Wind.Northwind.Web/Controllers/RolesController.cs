using Abp.Application.Services.Dto;
using Abp.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Wind.Northwind.Authorization;
using Wind.Northwind.Permissions;
using Wind.Northwind.Roles;
using Wind.Northwind.Web.Models.Roles;

namespace Wind.Northwind.Web.Controllers
{
    [AbpAuthorize(PermissionNames.Pages_Users)]
    public class RolesController : NorthwindControllerBase
    {
        private readonly IRoleAppService _roleAppService;
        private readonly IPermissionAppService _permissionAppservice;

        public RolesController(IRoleAppService roleAppService, IPermissionAppService permissionAppservice)
        {
            _roleAppService = roleAppService;
            _permissionAppservice = permissionAppservice;
        }

        
        // GET: Roles
        public ActionResult Index()
        {
            var permission = _permissionAppservice.GetListPermission()
                                                  .Items
                                                  .Select(p => new ComboboxItemDto(p.Name, new string('-', p.Level * 2) + " " + p.DisplayName))
                                                  .ToList();
            permission.Insert(0, new ComboboxItemDto("",""));

            var model = new RoleListViewModel() {
                Permissions = permission
            };

            return View(model);
        }

        public async Task<PartialViewResult> CreateOrEditModal(int? id)
        {
           // var output = await _roleAppService.GetRoleForEdit(new NullableIdDto { Id = id });
            //var viewModel = new CreateOrEditRoleModalViewModel(output);

            return PartialView("_CreateOrEditModal", null);
        }


    }
}