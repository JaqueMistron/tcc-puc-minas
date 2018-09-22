using Microsoft.EntityFrameworkCore;
using PucMinas.ControleCursos.WebAPI.Models.Interfaces;
using PucMinas.ControleCursos.WebAPI.Repositories.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PucMinas.ControleCursos.WebAPI.Repositories
{
    public abstract class GenericRepository<T> : IGeneric<T>, IDisposable where T : class
    {
        private readonly SqliteContext _context;
        protected DbSet<T> DbSet;

        protected GenericRepository(SqliteContext context)
        {
            _context = context;
            DbSet = _context.Set<T>();
        }

        public virtual void Insert(T entity)
        {
            DbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            DbSet.Update(entity);
        }

        public virtual void Delete(long id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return DbSet.AsNoTracking().Where(predicate);
        }

        public virtual T FindById(long id)
        {
            return DbSet.Find(id);
        }

        public virtual IEnumerable<T> FindAll()
        {
            return DbSet.AsNoTracking();
        }

        public bool Any(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Any(predicate);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
