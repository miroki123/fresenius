using Domain.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public abstract class Repository<T> where T : Entity
    {
        protected readonly ApplicationContext _context;
        protected readonly DbSet<T> _dbSet = null;

        public Repository(ApplicationContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        protected IQueryable<T> Queryable()
        {
            return _context.Set<T>().AsQueryable();
        }

        public List<T> Get()
        {
            return Queryable().ToList();
        }

        public List<T> Get(Expression<Func<T, bool>> predicate)
        {
            return Queryable().Where(predicate).ToList();
        }

        public T First(Expression<Func<T, bool>> predicate)
        {
            return Queryable().Where(predicate).FirstOrDefault();
        }

        public T GetById(int id)
        {
            return Queryable().FirstOrDefault(q => q.Id.Equals(id));
        }

        public void Insert(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            T delete = _dbSet.Find(entity.Id);
            if (delete != null)
            {
                _dbSet.Remove(delete);
                _context.SaveChanges();
            }
        }

        public void Update(T entity)
        {
            var local = _dbSet.Local.FirstOrDefault(l => l.Id.Equals(entity.Id));
            if (local != null)
                _context.Entry(local).State = EntityState.Detached;

            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }



    }
}
