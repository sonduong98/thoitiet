using Business;
using Models.FECategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTL_WEB.Controllers
{
    public class CategoryController : ClientController
    {
        // GET: Category
        private ApplicationService _applicationService = new ApplicationService();
        public ActionResult Index(string title)
        {
            var id = GetId(title);
            ViewData["PageInfo"] = _applicationService.InfoLayout();
            ViewData["IndexInfo"] = _applicationService.GetIndex();
            var model = new FECategoryModel();
            model = _applicationService.GetForCategory(id);
            return View(model);
        }
    }
}