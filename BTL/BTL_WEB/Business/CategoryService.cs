using Entities;
using Entities.Base;
using Models.Categories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Business
{
    public class CategoryService /*: GenericRepository<Category>*/
    {
        public BTLEntities _context = new BTLEntities();
        //public CategoryService(BTLEntities context) : base(context)
        //{
        //}
        public CategoryService()
        {

        }

        public IPagedList<Category> GetAll(GlobalParamFilter filters)
        {
            var query = _context.Categories.AsQueryable();

            if (!string.IsNullOrEmpty(filters.Keyword))
            {
                query = query.Where(c => c.Description.Contains(filters.Keyword) || c.Title.Contains(filters.Keyword) || c.Name.Contains(filters.Keyword) || c.KeyName.Contains(filters.Keyword) || c.Type.Contains(filters.Keyword)).AsQueryable();
            }
            query = query.OrderByDescending(c => c.CreateDate);
            var results = query.ToList();
            return new PagedList<Category>(results, filters.PageIndex, filters.PageSize);
        }
        public List<Category> getCategory()
        {
            return _context.Categories.ToList();
        }
        public void SaveCategory(CategoryModel model)
        {
            if (model.Id == 0)
            {
                Category data = new Category()
                {
                    Name = model.Name,
                    Title = model.Title,
                    SlugUrl = model.SlugUrl,
                    Url = model.Url,
                    Status=model.Status,
                    Description = model.Description,
                    KeyName = model.KeyName,
                    Keywords = model.Keywords,
                    ParentId = model.ParentId,
                    CreateDate = model.CreateDate,
                    CreatedBy = model.CreatedBy,
                    UpdateDate = model.UpdateDate,
                    UpdatedBy = model.UpdatedBy,
                    Type=model.Type,
                    Image=model.Image
                };
                _context.Categories.Add(data);
                _context.SaveChanges();
            }
            else
            {
                var data = _context.Categories.FirstOrDefault(c => c.Id == model.Id);
                data.Name = model.Name;
                data.Title = model.Title;
                data.SlugUrl = model.SlugUrl;
                data.Url = model.Url;
                data.Description = model.Description;
                data.Status = model.Status;
                data.KeyName = model.KeyName;
                data.Keywords = model.Keywords;
                data.ParentId = model.ParentId;
                data.CreateDate = DateTime.Now;
                data.CreatedBy = model.CreatedBy;
                data.UpdateDate = DateTime.Now;
                data.UpdatedBy = model.UpdatedBy;
                data.Type = model.Type;
                data.Image = model.Image;
                _context.SaveChanges();
            }
        }
    }
}
