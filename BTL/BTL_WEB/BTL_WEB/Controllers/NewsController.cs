using Business;
using Models.FEPost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTL_WEB.Controllers
{
    public class NewsController : ClientController
    {
        // GET: News
        private ApplicationService _applicationService = new ApplicationService();
        public ActionResult Index(string title)
        {
            var id = GetId(title);
            ViewData["PageInfo"] = _applicationService.InfoLayout();
            ViewData["IndexInfo"] = _applicationService.GetIndex();
            var model = new FEPostModel();
            model = _applicationService.FEPost(id);

            return View(model);
        }
    }
}