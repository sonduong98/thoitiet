using Entities;
using Models.Categories;
using Models.FECategory;
using Models.FEPost;
using Models.Layout;
using Models.Post;
using Models.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ApplicationService
    {
        private Entities.BTLEntities _context = new Entities.BTLEntities();
        public GetForLayout InfoLayout()
        {
            var data = new GetForLayout();
            var menu = _context.Categories.Where(c => c.Type == "Menu");
            menu = menu.OrderByDescending(c => c.UpdateDate);
            data.Menu.AddRange(menu.Select(c => new CategoryModel()
            {
                Title=c.Title,
                Id=c.Id,
                TotalPost=_context.Posts.Where(m=>m.CateId==c.Id).Count(),
                Url=c.SlugUrl +"-"+c.Id
            }));
            data.Top12Post.AddRange(_context.Posts.Take(12).OrderByDescending(s=>s.UpdateDate).Select(c => new PostModel()
            {
                Title = c.Title,
                Id = c.Id,
                Description = c.Description,
                UpdatedBy = c.UpdatedBy,
                Image = c.Image,
                UpdatedDate = c.UpdateDate.ToString(),
                NameCate=_context.Categories.FirstOrDefault(k=>k.Id==c.CateId).Title,
                UrlCate = _context.Categories.FirstOrDefault(k => k.Id == c.CateId).SlugUrl + "-" + _context.Categories.FirstOrDefault(k => k.Id == c.CateId).Id,
                Url =c.SlugUrl+"-"+c.Id
            }));
            data.InfoCategory.AddRange(_context.Categories.Where(c => c.Title != "HOME").Select(c => new CategoryModel()
            {
                Id = c.Id,
                Title = c.Title,
                TotalPost = _context.Posts.Where(s => s.CateId == c.Id).Count(),
                Url = c.SlugUrl + "-" + c.Id
            }));
            data.Tags.AddRange(_context.Tags.ToList().Select(c => new TagModel() {
                Id=c.Id,
                Name=c.Name
            }));
            data.PostPopular.AddRange(_context.Posts.AsQueryable().Take(4).OrderByDescending(c => c.CountView).ToList().Select(c => new PostModel()
            {
                Title = c.Title,
                Id = c.Id,
                Description = c.Description,
                UpdatedBy = c.UpdatedBy,
                Image = c.Image,
                UpdatedDate = c.UpdateDate.ToString(),
                NameCate = _context.Categories.FirstOrDefault(k => k.Id == c.CateId).Title,
                UrlCate = _context.Categories.FirstOrDefault(k => k.Id == c.CateId).SlugUrl + "-" + _context.Categories.FirstOrDefault(k => k.Id == c.CateId).Id,
                Url = c.SlugUrl + "-" + c.Id
            }));
            return data;
        }
        public IndexModel GetIndex()
        {
            var data = new IndexModel();
            data.Top7PostNew.AddRange(_context.Posts.Take(7).OrderByDescending(c => c.UpdateDate).Select(c => new PostModel()
            {
                Title = c.Title,
                Id = c.Id,
                Description = c.Description,
                UpdatedBy = c.UpdatedBy,
                Image = c.Image,
                UpdatedDate = c.UpdateDate.ToString(),
                NameCate = _context.Categories.FirstOrDefault(k => k.Id == c.CateId).Title,
                UrlCate = _context.Categories.FirstOrDefault(k => k.Id == c.CateId).SlugUrl + "-" + _context.Categories.FirstOrDefault(k => k.Id == c.CateId).Id,
                Url = c.SlugUrl + "-" + c.Id
            }));
            data.Top9PostByCate.AddRange(_context.Posts.Where(c=>c.CateId==1031).Take(3).Select(c => new PostModel()
            {
                Title = c.Title,
                Id = c.Id,
                Description = c.Description,
                UpdatedBy = c.UpdatedBy,
                Image = c.Image,
                UpdatedDate = c.UpdateDate.ToString(),
                NameCate = _context.Categories.FirstOrDefault(k => k.Id == c.CateId).Title,
                UrlCate = _context.Categories.FirstOrDefault(k => k.Id == c.CateId).SlugUrl + "-" + _context.Categories.FirstOrDefault(k => k.Id == c.CateId).Id,
                Url = c.SlugUrl + "-" + c.Id
            }));
            data.Top9PostByCate.AddRange(_context.Posts.Where(c => c.CateId == 1030 || c.CateId == 1034).Take(3).Select(c => new PostModel()
            {
                Title = c.Title,
                Id = c.Id,
                Description = c.Description,
                UpdatedBy = c.UpdatedBy,
                Image = c.Image,
                UpdatedDate = c.UpdateDate.ToString(),
                NameCate = _context.Categories.FirstOrDefault(k => k.Id == c.CateId).Title,
                UrlCate = _context.Categories.FirstOrDefault(k => k.Id == c.CateId).SlugUrl + "-" + _context.Categories.FirstOrDefault(k => k.Id == c.CateId).Id,
                Url = c.SlugUrl + "-" + c.Id
            }));
            data.Top9PostByCate.AddRange(_context.Posts.Where(c => c.CateId == 1032 || c.CateId == 1033).Select(c => new PostModel()
            {
                Title = c.Title,
                Id = c.Id,
                Description = c.Description,
                UpdatedBy = c.UpdatedBy,
                Image = c.Image,
                UpdatedDate = c.UpdateDate.ToString(),
                NameCate = _context.Categories.FirstOrDefault(k => k.Id == c.CateId).Title,
                UrlCate = _context.Categories.FirstOrDefault(k => k.Id == c.CateId).SlugUrl + "-" + _context.Categories.FirstOrDefault(k => k.Id == c.CateId).Id,
                Url = c.SlugUrl + "-" + c.Id
            }));
            return data;
        } 
        public FEPostModel FEPost(int? id)
        {
            var data = new FEPostModel();
            var post = _context.Posts.FirstOrDefault(c => c.Id == id);
            data.PostDetail = new PostModel()
            {
                Title = post.Title,
                SlugUrl = post.SlugUrl,
                Contents = post.Contents,
                NameCate = _context.Categories.FirstOrDefault(k => k.Id == post.CateId).Title,
                Description = post.Description,
                UpdatedDate = DateTime.Now.ToString(),
                Tags = post.Tags,
                Status = post.Status,
                UpdatedBy = post.UpdatedBy,
                Image = post.Image,
                Keywords = post.Keywords,
                Name = post.Name,
                CateId=post.CateId,
                UrlCate = _context.Categories.FirstOrDefault(k => k.Id == post.CateId).SlugUrl + "-" + _context.Categories.FirstOrDefault(k => k.Id == post.CateId).Id
            };
            data.Top3PostRelative.AddRange(_context.Posts.Where(c => c.CateId == post.CateId || c.Tags == post.Tags).Take(3).Select(c => new PostModel()
            {
                Title = c.Title,
                Id = c.Id,
                Description = c.Description,
                UpdatedBy = c.UpdatedBy,
                Image = c.Image,
                UpdatedDate = c.UpdateDate.ToString(),
                NameCate = _context.Categories.FirstOrDefault(k => k.Id == c.CateId).Title,
                Url = c.SlugUrl + "-" + c.Id,
                UrlCate = _context.Categories.FirstOrDefault(k => k.Id == c.CateId).SlugUrl + "-" + _context.Categories.FirstOrDefault(k => k.Id == c.CateId).Id
            }));
            data.PostNext.AddRange(_context.Posts.OrderByDescending(c => c.UpdateDate).Take(2).Select(c => new PostModel()
            {
                Title = c.Title,
                Id = c.Id,
                Description = c.Description,
                UpdatedBy = c.UpdatedBy,
                Image = c.Image,
                UpdatedDate = c.UpdateDate.ToString(),
                NameCate = _context.Categories.FirstOrDefault(k => k.Id == c.CateId).Title,
                Url = c.SlugUrl + "-" + c.Id,
                UrlCate = _context.Categories.FirstOrDefault(k => k.Id == c.CateId).SlugUrl + "-" + _context.Categories.FirstOrDefault(k => k.Id == c.CateId).Id,
            }));
            return data;
        } 
        public FECategoryModel GetForCategory(int? id)
        {
            var data = new FECategoryModel();
            var cate = _context.Categories.FirstOrDefault(c => c.Id == id);
            data.CategoryDetail = new CategoryModel()
            {
                Title = cate.Title,
                Id=cate.Id,
                Image=cate.Image
            };
            var listPost = _context.Posts.Where(c => c.CateId == id).ToList();
            data.PostByCategory.AddRange(listPost.Select(c => new PostModel()
            {
                Title = c.Title,
                Id = c.Id,
                Description = c.Description,
                UpdatedBy = c.UpdatedBy,
                Image = c.Image,
                UpdatedDate = c.UpdateDate.ToString(),
                NameCate = _context.Categories.FirstOrDefault(k => k.Id == c.CateId).Title,
                UrlCate= _context.Categories.FirstOrDefault(k => k.Id == c.CateId).SlugUrl + "-" + _context.Categories.FirstOrDefault(k => k.Id == c.CateId).Id,
                Url = c.SlugUrl + "-" + c.Id
            }));
            return data;
        }
    }
}
