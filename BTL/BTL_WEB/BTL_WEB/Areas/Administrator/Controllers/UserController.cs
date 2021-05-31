using Business;
using Entities;
using Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTL_WEB.Areas.Administrator.Controllers
{
    public class UserController : Controller
    {
        // GET: Administrator/User
        private UserService _user = new UserService();
        private UserViewModel models = new UserViewModel();
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
                var data = _user.GetAll(filters);
                foreach (var item in data)
                {
                    models.ListUsers.Add(new UserModel()
                    {
                        Id = item.Id,
                        FirstName=item.FirstName,
                        LastName=item.LastName,
                        UserName=item.UserName,
                        UpdatedDate=item.UpdatedDate.ToString(),
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

        public ActionResult UserEditor(int? id)
        {

            var userObj = _context.Users.FirstOrDefault(m => m.Id == id);
            if (userObj == null)
            {
                userObj = new User();
            }
            else
            {
                models.InfoUser = new UserModel()
                {
                    Id = userObj.Id,
                    UserName = userObj.UserName,
                    FirstName = userObj.FirstName,
                    LastName = userObj.LastName,
                    UpdatedDate = userObj.UpdatedDate.ToString(),
                    UpdatedBy = userObj.UpdatedBy
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
        public ActionResult UserEditor(UserViewModel model)
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
                model.InfoUser.UpdatedBy = (int)Session["ID"];
                model.InfoUser.CreatedBy = (int)Session["ID"];
                
                _user.SaveCategory(model.InfoUser);

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
                _context.Users.Remove(_context.Users.FirstOrDefault(c => c.Id == id));
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