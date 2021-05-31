using Entities;
using Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class UserService
    {
        public BTLEntities _context = new BTLEntities();
        //public CategoryService(BTLEntities context) : base(context)
        //{
        //}
        public UserService()
        {

        }

        public IPagedList<User> GetAll(GlobalParamFilter filters)
        {
            var query = _context.Users.AsQueryable();

            if (!string.IsNullOrEmpty(filters.Keyword))
            {
                query = query.Where(c => c.UserName.Contains(filters.Keyword));
            }
            query = query.OrderByDescending(c => c.UpdatedDate);
            var results = query.ToList();
            return new PagedList<User>(results, filters.PageIndex, filters.PageSize);
        }
        public List<User> getUser()
        {
            return _context.Users.ToList();
        }
        public void SaveCategory(UserModel model)
        {
            if (model.Id == 0)
            {
                User data = new User()
                {
                    FirstName=model.FirstName,
                    LastName=model.LastName,
                    UserName=model.UserName,
                    Password=model.Password,
                    UpdatedDate=DateTime.Now                  
                };
                _context.Users.Add(data);
                _context.SaveChanges();
            }
            else
            {
                var data = _context.Users.FirstOrDefault(c => c.Id == model.Id);
                data.UserName = model.UserName;
                data.Password = model.Password;
                data.FirstName = model.FirstName;
                data.LastName = model.LastName;
                data.UpdatedDate = DateTime.Now;
                data.UpdatedBy = model.UpdatedBy;
                _context.SaveChanges();
            }
        }
    }
}
