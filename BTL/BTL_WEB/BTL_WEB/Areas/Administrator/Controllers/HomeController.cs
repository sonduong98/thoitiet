﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTL_WEB.Areas.Administrator.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Administrator/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}