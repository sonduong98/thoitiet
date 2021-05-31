using System;
using System.Data.Entity;
using System.Linq;

namespace Entities.Base
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class, new()
    {
        public BTLEntities _context { get; }

        public GenericRepository(BTLEntities context)
        {
            _context = context;
        }

        public virtual IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public virtual IQueryable<T> FindAllBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public virtual T FirstOrDefault(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().FirstOrDefault(predicate);
        }

        public virtual void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public virtual void Add(IQueryable<T> entities)
        {
            foreach (T entity in entities.ToList())
                _context.Set<T>().Add(entity);
        }

        public virtual void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public virtual void Delete(IQueryable<T> entities)
        {
            foreach (T entity in entities.ToList())
                _context.Set<T>().Remove(entity);
        }

        public virtual void Edit(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Edit(IQueryable<T> entities)
        {
            foreach (T entity in entities.ToList())
                _context.Entry(entity).State = EntityState.Modified;
        }
        public virtual int Save()
        {
            try
            {
                return _context.SaveChanges();
            }

            catch //(Exception ex)
            {
                return 0;
            }
        }

        public virtual T Find(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Refresh(T entity)
        {
            _context.Entry(entity).Reload();
        }

        public virtual int Count(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Count(predicate);
        }
        public virtual int Count()
        {
            return _context.Set<T>().Count();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
