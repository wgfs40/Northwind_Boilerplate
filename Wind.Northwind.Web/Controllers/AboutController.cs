using Abp.Web.Mvc.Authorization;
using System.Web.Mvc;
using Wind.Northwind.Authorization;

namespace Wind.Northwind.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_User_Create)]
    public class AboutController : NorthwindControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}