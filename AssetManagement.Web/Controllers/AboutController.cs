using System.Web.Mvc;

namespace AssetManagement.Web.Controllers
{
    public class AboutController : AssetManagementControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}