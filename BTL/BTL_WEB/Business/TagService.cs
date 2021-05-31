using Entities;
using Models.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class TagService
    {
        public BTLEntities _context = new BTLEntities();
        //public CategoryService(BTLEntities context) : base(context)
        //{
        //}
        public TagService()
        {

        }
        public IPagedList<Tag> GetAll(GlobalParamFilter filters)
        {
            var query = _context.Tags.AsQueryable();

            if (!string.IsNullOrEmpty(filters.Keyword))
            {
                query = query.Where(c => c.Name.Contains(filters.Keyword));
            }
            query = query.OrderByDescending(c => c.UpdateDate);
            var results = query.ToList();
            return new PagedList<Tag>(results, filters.PageIndex, filters.PageSize);
        }
        //public List<User> getUser()
        //{
        //    return _context.Users.ToList();
        //}
        public void SaveTag(TagModel model)
        {
            if (model.Id == 0)
            {
                Tag data = new Tag()
                {
                    Name=model.Name,
                    UpdateDate = DateTime.Now
                };
                _context.Tags.Add(data);
                _context.SaveChanges();
            }
            else
            {
                var data = _context.Tags.FirstOrDefault(c => c.Id == model.Id);
                data.Name = model.Name;   
                data.UpdateDate = DateTime.Now;
                data.UpdatedBy = model.UpdatedBy;
                _context.SaveChanges();
            }
        }
    }
}
