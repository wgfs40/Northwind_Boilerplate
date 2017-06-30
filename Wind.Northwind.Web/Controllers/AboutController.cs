using System.Web.Mvc;

namespace Wind.Northwind.Web.Controllers
{
    public class AboutController : NorthwindControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}