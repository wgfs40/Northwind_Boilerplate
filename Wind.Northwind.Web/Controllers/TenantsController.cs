using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;
using Wind.Northwind.Authorization;
using Wind.Northwind.MultiTenancy;

namespace Wind.Northwind.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Tenants)]
    public class TenantsController : NorthwindControllerBase
    {
        private readonly ITenantAppService _tenantAppService;

        public TenantsController(ITenantAppService tenantAppService)
        {
            _tenantAppService = tenantAppService;
        }

        public ActionResult Index()
        {
            var output = _tenantAppService.GetTenants();
            return View(output);
        }
    }
}