using Business;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using HtmlAgilityPack;
using System.Configuration;
using System.IO;
using System.Text;
using System.Net.Http;

namespace BTL_WEB.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationService _applicationService = new ApplicationService();
        public ActionResult Index()
        {

             



            ViewData["PageInfo"] = _applicationService.InfoLayout();
            ViewData["IndexInfo"] = _applicationService.GetIndex();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}