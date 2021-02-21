using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //InMemoryCarDalTest();

            EFCarDalTest();
        }

        private static void EFCarDalTest()
        {
            // Test of EFCarDal 
            CarManager carManager = new CarManager(new EFCarDal());

            var cars = carManager.GetAll();
            foreach (var car in cars)
            {
                Console.WriteLine("CarId:{0} Description:{1} ModelYear:{2} DailyPrice{3}",
                                    car.Id, car.Description, car.ModelYear, car.DailyPrice);
            }

            Console.WriteLine("************************************************");

            var car1 = carManager.GetById(1);
            if (car1 != null)
                Console.WriteLine("CarId:{0} Description:{1} ModelYear:{2} DailyPrice{3}",
                                    car1.Id, car1.Description, car1.ModelYear, car1.DailyPrice);

            Console.WriteLine("************************************************");

            var carsByBrandId = carManager.GetCarsByBrandId(1);
            foreach (var car in carsByBrandId)
            {
                Console.WriteLine("CarId:{0} Description:{1} ModelYear:{2} DailyPrice{3} BrandId:{4}",
                                    car.Id, car.Description, car.ModelYear, car.DailyPrice, car.BrandId);
            }

            Console.WriteLine("************************************************");

            var carsByColorId = carManager.GetCarsByColorId(1);
            foreach (var car in carsByColorId)
            {
                Console.WriteLine("CarId:{0} Description:{1} ModelYear:{2} DailyPrice{3} ColorId:{4}",
                                    car.Id, car.Description, car.ModelYear, car.DailyPrice, car.ColorId);
            }

            Console.WriteLine("************************************************");

            Car car2 = new Car()
            {
                BrandId = 1,
                ColorId = 1,
                ModelYear = new DateTime(2020, 1, 1),
                DailyPrice = 2000000,
                Description = "Description of car3",
                Name = "a"
            };

            carManager.Add(car2);

            Car car3 = new Car()
            {
                BrandId = 1,
                ColorId = 1,
                ModelYear = new DateTime(2020, 1, 1),
                DailyPrice = 1000000,
                Description = "Description of car4",
                Name = "Name of car4"
            };

            carManager.Add(car3);
        }

        private static void InMemoryCarDalTest()
        {
            // Test of InMemoryCarDal 
            CarManager carManager = new CarManager(new InMemoryCarDal());

            var cars = carManager.GetAll();
            foreach (var car in cars)
            {
                Console.WriteLine("CarId:{0} Description:{1} ModelYear:{2} DailyPrice{3}",
                                    car.Id, car.Description, car.ModelYear, car.DailyPrice);
            }

            Console.WriteLine("************************************************");

            var car1 = carManager.GetById(1);
            if (car1 != null)
                Console.WriteLine("CarId:{0} Description:{1} ModelYear:{2} DailyPrice{3}",
                                    car1.Id, car1.Description, car1.ModelYear, car1.DailyPrice);
        }
    }
}
