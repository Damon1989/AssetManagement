using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace AssetManagement.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : AssetManagementControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}