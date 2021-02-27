using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        [Obsolete("Dont use Add, instead use AddNew Method")]
        public void Add(TEntity entity)
        {
            using (TContext _context = new TContext())
            {
                var addedEntity = _context.Entry(entity);
                addedEntity.State = EntityState.Added;
                _context.SaveChanges();
            }
        }

        public void AddNew(TEntity entity)
        {
            using (TContext _context = new TContext())
            {
                var addedEntity = _context.Entry(entity);
                addedEntity.State = EntityState.Added;
                _context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext _context = new TContext())
            {
                var deletedEntity = _context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                _context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext _context = new TContext())
            {
                return _context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext _context = new TContext())
            {
                return filter == null ?
                        _context.Set<TEntity>().ToList() :
                        _context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext _context = new TContext())
            {
                var updatedEntity = _context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                _context.SaveChanges();
            }
        }
    }
}