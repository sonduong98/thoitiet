using Business;
using Entities;
using Models.Post;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTL_WEB.Areas.Administrator.Controllers
{
    public class PostController : Controller
    {
        private PostService _post = new PostService();
        private PostViewModel models = new PostViewModel();
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
                var cates = _context.Categories.ToList();
                var data = _post.GetAll(filters);
                foreach (var item in data)
                {
                    models.ListPosts.Add(new PostModel()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Title = item.Title,
                        Description = item.Description,
                        Status = item.Status,
                        UpdatedDate = item.UpdateDate.ToString(),   
                        NameCate = cates.FirstOrDefault(c => c.Id == item.CateId).Title       
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

        // GET: Administrator/Post/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Administrator/Post/Create
        public ActionResult Create()
        {
            var listCates = _context.Categories.ToList();
            models.Cates.AddRange(listCates.Select(c => new SelectListItem()
            {
                Text = c.Title,
                Value = c.Id.ToString()
            }));
            var listTags = _context.Tags.ToList();
            models.ListTags.AddRange(listTags.Select(c => new SelectListItem()
            {
                Text = c.Name,
                Value = c.Id.ToString()
            }));
            return View(models);
        }

        // POST: Administrator/Post/Create
        [HttpPost]
        public ActionResult Create(PostViewModel model, HttpPostedFileBase file)
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
                    model.InfoPost.Image = "/Uploads/" + Path.GetFileName(file.FileName);
                }
                // TODO: Add insert logic here

                // model.InfoPost.UpdatedBy = (int)Session["ID"];
                model.InfoPost.UpdatedDate = DateTime.Now.ToString();
                _post.SavePost(model.InfoPost);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Administrator/Post/Edit/5
        public ActionResult Edit(int id)
        {
            var data = _context.Posts.FirstOrDefault(c => c.Id == id);
            models.InfoPost.Id = data.Id;
            models.InfoPost.Name = data.Name;
            models.InfoPost.Title = data.Title;
            models.InfoPost.Description = data.Description;
            models.InfoPost.Contents = data.Contents;
            models.InfoPost.Image = data.Image;
            models.InfoPost.Keywords = data.Keywords;
            models.InfoPost.Tags = data.Tags;
            models.InfoPost.SlugUrl = data.SlugUrl;
            models.InfoPost.Status = data.Status;
            models.InfoPost.CateId = data.CateId;
            models.InfoPost.Tags = data.Tags;

            var listCates = _context.Categories.ToList();
            models.Cates.AddRange(listCates.Select(c => new SelectListItem()
            {
                Text = c.Title,
                Value = c.Id.ToString()
            }));
            var listTags = _context.Tags.ToList();
            models.ListTags.AddRange(listTags.Select(c => new SelectListItem()
            {
                Text = c.Name,
                Value = c.Id.ToString()
            }));
            return View(models);
        }

        // POST: Administrator/Post/Edit/5
        [HttpPost]
        public ActionResult Edit(PostViewModel model, HttpPostedFileBase file)
        {
            try
            {
                var data = _context.Posts.FirstOrDefault(c => c.Id == model.InfoPost.Id);
                if (file != null)
                {
                    string path = Server.MapPath("~/Uploads/");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    file.SaveAs(path + Path.GetFileName(file.FileName));
                    data.Image= "/Uploads/" + Path.GetFileName(file.FileName);
                }

                

                data.Title = model.InfoPost.Title;
                data.SlugUrl = model.InfoPost.SlugUrl;
                data.Contents = model.InfoPost.Contents;
                data.CateId = model.InfoPost.CateId;
                data.Description = model.InfoPost.Description;
                data.UpdateDate = DateTime.Now;
                data.Tags = model.InfoPost.Tags;
                data.Status = model.InfoPost.Status;
                data.UpdatedBy = model.InfoPost.UpdatedBy;
                data.Keywords = model.InfoPost.Keywords;
                data.Name = model.InfoPost.Name;

                // TODO: Add update logic here
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Administrator/Post/Delete/5
        public ActionResult Delete(int id)
        {
            _context.Posts.Remove(_context.Posts.FirstOrDefault(c => c.Id == id));
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: Administrator/Post/Delete/5

    }
}
