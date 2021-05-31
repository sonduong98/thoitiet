using Entities;
using Models.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class PostService
    {
        public BTLEntities _context = new BTLEntities();
        //public CategoryService(BTLEntities context) : base(context)
        //{
        //}
        public PostService()
        {

        }
        public IPagedList<Post> GetAll(GlobalParamFilter filters)
        {
            var query = _context.Posts.AsQueryable();

            if (!string.IsNullOrEmpty(filters.Keyword))
            {
                query = query.Where(c => c.Name.Contains(filters.Keyword) || c.Title.Contains(filters.Keyword) || c.Description.Contains(filters.Keyword) || c.Contents.Contains(filters.Keyword));
            }
            query = query.OrderByDescending(c => c.UpdateDate);
            var results = query.ToList();
            return new PagedList<Post>(results, filters.PageIndex, filters.PageSize);
        }
        public void SavePost(PostModel model)
        {
            var data = new Post()
            {
                Title = model.Title,
                SlugUrl = model.SlugUrl,
                Contents = model.Contents,
                CateId = model.CateId,
                Description = model.Description,
                UpdateDate = DateTime.Now,
                Tags = model.Tags,
                Status = model.Status,
                UpdatedBy = model.UpdatedBy,
                Image = model.Image,
                Keywords = model.Keywords,
                Name=model.Name
            };
            _context.Posts.Add(data);
            _context.SaveChanges();
        }
    }
}
