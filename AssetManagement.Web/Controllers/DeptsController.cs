﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AssetManagement.Web.Controllers
{
    public class DeptsController : AssetManagementControllerBase
    {
        // GET: Dept
        public ActionResult Index()
        {
            return View();
        }
    }
}