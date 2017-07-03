using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;
using Wind.Northwind.Authorization;

namespace Wind.Northwind.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : NorthwindControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}