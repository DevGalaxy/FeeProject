using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace Infrastructure.DataAccess.Repository.IRepository
{
    public interface IRopository<T> where T : class
    {
        T Get(int id);
        IEnumerable<T> GetAll(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> OrdredBy=null,
            string includedPropperties = null
            );
        T GetFirstOrDefault(
            Expression<Func<T, bool>> filter = null,
            string includePropperties = null
            );
        void Add(T entity);
        void Remove(int id);
        void Remove(T entity);
        void Update(T entity);
    }
}
