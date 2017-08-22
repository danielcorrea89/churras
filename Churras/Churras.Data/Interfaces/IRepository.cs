using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Churras.Data
{
    public interface IRepository<T> where T : class
    {
        T Add(T t);
        int Count();
        void Delete(T t);
        T Find(Expression<Func<T, bool>> match);
        ICollection<T> FindAll(Expression<Func<T, bool>> match);
        T Get(int id);
        ICollection<T> GetAll();
        T Update(T updated, int key);
    }
}