using Business;
using Entities;
using Models.Categories;
using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace BTL_WEB.Areas.Administrator.Controllers
{
    public class CategoryController : BaseController
    {
        // GET: Administrator/Category
        private CategoryService _category = new CategoryService();
        private CategoryViewModel models = new CategoryViewModel();
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
                var data = _category.GetAll(filters);
                foreach(var item in data)
                {
                    models.ListCategories.Add(new CategoryModel()
                    {
                        Id=item.Id,
                        Name=item.Name,
                        Title=item.Title,
                        SlugUrl=item.SlugUrl,
                        Url=item.Url,
                        Description=item.Description,
                        KeyName=item.KeyName,
                        Keywords=item.Keywords,
                        ParentId=item.ParentId,
                        CreateDate=item.CreateDate,
                        CreatedBy=item.CreatedBy,
                        UpdateDate=item.UpdateDate,
                        UpdatedBy=item.UpdatedBy
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
            var listCate = _category.getCategory();
            if (listCate.Any())
            {
                object p = listCate.Select(o => {
                    var result = new SelectListItem
                    {
                        Value = o.Id.ToString(),
                        Text = o.Name
                    };
                    models.NameCategories.Add(result);
                    //you miss this
                    return result;
                });
            }
            
            return View(models);
        }

        public ActionResult CategoryEditor(int? id)
        {
            
            var categoryObj = _context.Categories.FirstOrDefault(m => m.Id == id);
            if (categoryObj == null)
            {
                categoryObj = new Category();
            }
            else
            {
                models.InfoCategory = new CategoryModel()
                {
                    Id=categoryObj.Id,
                    Name = categoryObj.Name,
                    Title = categoryObj.Title,
                    SlugUrl = categoryObj.SlugUrl,
                    Url = categoryObj.Url,
                    Status=categoryObj.Status,
                    Description = categoryObj.Description,
                    KeyName = categoryObj.KeyName,
                    Keywords = categoryObj.Keywords,
                    ParentId = categoryObj.ParentId,
                    CreateDate = categoryObj.CreateDate,
                    CreatedBy = categoryObj.CreatedBy,
                    UpdateDate = categoryObj.UpdateDate,
                    UpdatedBy = categoryObj.UpdatedBy,
                    Image=categoryObj.Image
                };
            }
            
            var listCate = _category.getCategory();
            if (listCate.Any())
            {
                object p = listCate.Select(o => {
                    var result = new SelectListItem
                    {
                        Value = o.Id.ToString(),
                        Text = o.Name
                    };
                    models.NameCategories.Add(result);
                    //you miss this
                    return result;
                });
            }
            return View(models);
        }

        [HttpPost]
        public ActionResult CategoryEditor(CategoryViewModel model, HttpPostedFileBase file)
        {
            try
            {
                if (file != null)
                {
                    string path = Server.MapPath("~/Uploads/");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    file.SaveAs(path + Path.GetFileName(file.FileName));
                    model.InfoCategory.Image = "/Uploads/" + Path.GetFileName(file.FileName);
                }
                model.InfoCategory.UpdateDate = DateTime.Now;
                model.InfoCategory.CreateDate = DateTime.Now;
                model.InfoCategory.UpdatedBy = (int)Session["ID"];
                model.InfoCategory.CreatedBy = (int)Session["ID"];
                _category.SaveCategory(model.InfoCategory);
              
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
                _context.Categories.Remove(_context.Categories.FirstOrDefault(c => c.Id == id));
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
