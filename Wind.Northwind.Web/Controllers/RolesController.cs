using Abp.Application.Services.Dto;
using Abp.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wind.Northwind.Permissions;
using Wind.Northwind.Roles;

namespace Wind.Northwind.Web.Controllers
{
    [AbpAuthorize]
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
                                                  .Select(p => new ComboboxItemDto(p.Name, ""));
            return View();
        }
    }
}