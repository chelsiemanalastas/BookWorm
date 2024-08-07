using Book.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Book.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _db;
        internal DbSet<T> dbSet;

        public Repository(AppDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
            _db.Products.Include(u => u.Category);
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }

        public T Get(Expression<Func<T, bool>> predicate, string? includeProp = null)
        {
            IQueryable<T> query = dbSet.Where(predicate);
            query = query.Where(predicate);
            if (!string.IsNullOrEmpty(includeProp))
            {
                foreach (var item in includeProp.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);
                }
            }
            return query.FirstOrDefault();
        }

        //Category,CoverType
        public IEnumerable<T> GetAll(string? includeProp = null)
        {
            IQueryable<T> query = dbSet;
            if (!string.IsNullOrEmpty(includeProp))
            {
                foreach (var item in includeProp.Split(new char[] { ','}, StringSplitOptions.RemoveEmptyEntries))
                { 
                    query = query.Include(item);
                }
            }
            return query.ToList();
        }
    }
}
