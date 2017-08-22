using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Churras.Data
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private DbContext Context;

        public GenericRepository(DbContext context)
        {
            Context = context;
            Context.Configuration.LazyLoadingEnabled = true;
        }

        public ICollection<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public T Get(int id)
        {
            return Context.Set<T>().Find(id);
        }

        public T Find(Expression<Func<T, bool>> match)
        {
            return Context.Set<T>().SingleOrDefault(match);
        }

        public ICollection<T> FindAll(Expression<Func<T, bool>> match)
        {
            return Context.Set<T>().Where(match).ToList();
        }

        public T Add(T t)
        {
            Context.Set<T>().Add(t);
            Context.SaveChanges();
            return t;
        }

        public T Update(T updated, int key)
        {
            if (updated == null)
                return null;

            T existing = Context.Set<T>().Find(key);
            if (existing != null)
            {
                Context.Entry(existing).CurrentValues.SetValues(updated);
                Context.SaveChanges();
            }
            return existing;
        }

        public void Delete(T t)
        {
            Context.Set<T>().Remove(t);
            Context.SaveChanges();
        }

        public int Count()
        {
            return Context.Set<T>().Count();
        }
    }
}
    
