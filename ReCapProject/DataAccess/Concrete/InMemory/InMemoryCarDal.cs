using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car
                {
                    Id=1,
                    BrandId=1,
                    ColorId=1,
                    ModelYear=new DateTime(1993, 1, 1),
                    DailyPrice=150000,
                    Description="Description of car1",
                    Name="Name of car1"
                },
                new Car
                {
                    Id=2,
                    BrandId=1,
                    ColorId=1,
                    ModelYear=new DateTime(1996, 1, 1),
                    DailyPrice=250000,
                    Description="Description of car2",
                    Name="Name of car2"
                }
            };
        }

        public void Add(Car car)
        {
            Car _car = _cars.SingleOrDefault(c => c.Id == car.Id);

            if (_car == null)
            {
                _cars.Add(car);
            }
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);

            if (carToDelete != null)
            {
                _cars.Remove(carToDelete);
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return _cars;
        }

        public Car GetById(int carId)
        {
            return _cars.SingleOrDefault(c => c.Id == carId);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);

            if (carToUpdate != null)
            {
                carToUpdate.BrandId = car.BrandId;
                carToUpdate.ColorId = car.ColorId;
                carToUpdate.DailyPrice = car.DailyPrice;
                carToUpdate.Description = car.Description;
                carToUpdate.ModelYear = car.ModelYear;
            }
        }
    }
}
