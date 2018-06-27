using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AssetManagement.Web.Controllers
{
    public class VocabularyController : AssetManagementControllerBase
    {
        // GET: Vocabulary
        public ActionResult Index()
        {
            return View();
        }
    }
}