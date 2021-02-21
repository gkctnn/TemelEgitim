using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            using (ReCapDbContext _context = new ReCapDbContext())
            {
                var addedEntity = _context.Entry(entity);
                addedEntity.State = EntityState.Added;
                _context.SaveChanges();
            }
        }

        public void Delete(Car entity)
        {
            using (ReCapDbContext _context = new ReCapDbContext())
            {
                var deletedEntity = _context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                _context.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (ReCapDbContext _context = new ReCapDbContext())
            {
                return _context.Set<Car>().SingleOrDefault(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (ReCapDbContext _context = new ReCapDbContext())
            {
                return filter == null ?
                        _context.Set<Car>().ToList() :
                        _context.Set<Car>().Where(filter).ToList();
            }
        }

        public Car GetById(int carId)
        {
            return Get(c => c.Id == carId);
        }

        public void Update(Car entity)
        {
            using (ReCapDbContext _context = new ReCapDbContext())
            {
                var updatedEntity = _context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                _context.SaveChanges();
            }
        }
    }
}
