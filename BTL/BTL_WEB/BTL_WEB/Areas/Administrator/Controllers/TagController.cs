using Business;
using Entities;
using Models.Tags;
using Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTL_WEB.Areas.Administrator.Controllers
{
    public class TagController : Controller
    {
        private TagService _tag = new TagService();
        private TagViewModel models = new TagViewModel();
        private Entities.BTLEntities _context = new Entities.BTLEntities();
        public ActionResult Index(string sortBy, string orderBy, string keyword, int pageIndex = 1, int pageSize = 10, string type = "")
        {
            try
            {
                GlobalParamFilter filters = new GlobalParamFilter
                {
                    OrderBy = orderBy,
                    SortBy = sortBy,
                    PageIndex = pageIndex,
                    PageSize = pageSize > 0 ? pageSize : int.MaxValue,
                    Keyword = keyword,
                    Type = type
                };
                var data = _tag.GetAll(filters);
                foreach (var item in data)
                {
                    models.ListTags.Add(new TagModel()
                    {
                        Id = item.Id,
                        Name=item.Name,
                        UpdatedDate = item.UpdateDate.ToString(),
                    });
                }
                models.keyWord = keyword;
                models.PageIndex = pageIndex;
                models.PageSize = pageSize;
                models.TotalPages = data.TotalPages;
                models.TotalCount = data.TotalCount;
                return View(models);
            }
            catch (Exception ex)
            {

                return View();
            }
        }

        // GET: Administrator/Category/Create
        public ActionResult Create()
        {
            //var listCate = _category.getCategory();
            //if (listCate.Any())
            //{
            //    object p = listCate.Select(o => {
            //        var result = new SelectListItem
            //        {
            //            Value = o.Id.ToString(),
            //            Text = o.Name
            //        };
            //        models.NameCategories.Add(result);
            //        //you miss this
            //        return result;
            //    });
            //}

            return View(models);
        }

        public ActionResult TagEditor(int? id)
        {

            var tagObj = _context.Tags.FirstOrDefault(m => m.Id == id);
            if (tagObj == null)
            {
                tagObj = new Tag();
            }
            else
            {
                models.InfoTag = new TagModel()
                {
                    Id = tagObj.Id,
                    Name = tagObj.Name, 
                    UpdatedDate = tagObj.UpdateDate.ToString(),
                    UpdatedBy = tagObj.UpdatedBy
                };
            }

            //var listCate = _category.getCategory();
            //if (listCate.Any())
            //{
            //    object p = listCate.Select(o => {
            //        var result = new SelectListItem
            //        {
            //            Value = o.Id.ToString(),
            //            Text = o.Name
            //        };
            //        models.NameCategories.Add(result);
            //        //you miss this
            //        return result;
            //    });
            //}
            return View(models);
        }

        [HttpPost]
        public ActionResult TagEditor(TagViewModel model)
        {
            try
            {
                //if (!ModelState.IsValid) return View(model);

                //var data = _categoryService.FirstOrDefault(c => c.Title == model.InfoCategory.Title && c.Id != model.InfoCategory.Id);
                //if (data != null)
                //{
                //    ModelState.AddModelError("Title" + string.Empty, "The Title is exists");
                //    return View(model);
                //}
                model.InfoTag.UpdatedBy = (int)Session["ID"];
                model.InfoTag.CreatedBy = (int)Session["ID"];

                _tag.SaveTag(model.InfoTag);

                return View(model);
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        public ActionResult Delete(int? id)
        {
            try
            {
                _context.Tags.Remove(_context.Tags.FirstOrDefault(c => c.Id == id));
                _context.SaveChanges();
                // TODO: Add delete logic here
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}