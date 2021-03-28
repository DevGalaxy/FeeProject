using Infrastructure.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Infrastructure.DataAccess.Repository
{
    public class Repository<T> : IRopository<T> where T : class
    {
        protected readonly DbContext context;
        internal DbSet<T> dbset;
        public Repository(DbContext Context)
        {
            context = Context;
            this.dbset = context.Set<T>();

        }

        public void Add(T entity)
        {
            dbset.Add(entity);
        }

        public T Get(int id)
        {
            return dbset.Find(id);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> OrdredBy = null, string includedPropperties = null)
        {
            IQueryable<T> query = dbset;
            if(filter != null)
            {
                query.Where(filter);
            }
            if ( includedPropperties!= null)
            {
                foreach (var includedProppertie in includedPropperties.Split(new char[] { ',' },StringSplitOptions.RemoveEmptyEntries))
                {
                    query.Include(includedProppertie);
                }
            }
            if (OrdredBy != null)
            {
                return OrdredBy(query).ToList();
            }
            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string includePropperties = null)
        {
            IQueryable<T> query = dbset;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            // the include
            if (includePropperties != null)
            {
                foreach (var includrProperty in includePropperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includrProperty);
                }
            }
            return query.FirstOrDefault();
        }
        public void Remove(T entity)
        {
            dbset.Remove(entity);
        }
        public void Remove(int id)
        {
            T formDB = dbset.Find(id);
            Remove(formDB);
        }

    }
}
