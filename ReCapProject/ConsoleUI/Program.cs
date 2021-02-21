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

            //EFCarDtoTest();
        }

        private static void EFCarDtoTest()
        {
            CarManager carManager = new CarManager(new EFCarDal());

            var carDetailsResult = carManager.GetCarDetails();
            if (carDetailsResult.Success)
            {
                foreach (var car in carDetailsResult.Data)
                {
                    Console.WriteLine("CarName: {0} -- BrandName: {1} -- ColorName: {2} -- DailyPrice: {3}",
                                        car.CarName, car.BrandName, car.ColorName, car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(carDetailsResult.Message);
            }
        }

        private static void EFCarDalTest()
        {
            // Test of EFCarDal 
            CarManager carManager = new CarManager(new EFCarDal());

            var carsResult = carManager.GetAll();
            if (carsResult.Success)
            {
                foreach (var car in carsResult.Data)
                {
                    Console.WriteLine("CarId: {0} -- Description: {1} -- ModelYear: {2} -- DailyPrice: {3}",
                                        car.Id, car.Description, car.ModelYear, car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(carsResult.Message);
            }

            Console.WriteLine("************************************************");

            var carResult1 = carManager.GetById(1);
            if (carResult1.Success)
            {
                if (carResult1.Data != null)
                    Console.WriteLine("CarId: {0} -- Description: {1} -- ModelYear: {2} -- DailyPrice: {3}",
                                        carResult1.Data.Id, carResult1.Data.Description, carResult1.Data.ModelYear, carResult1.Data.DailyPrice);
            }
            else
            {
                Console.WriteLine(carResult1.Message);
            }

            Console.WriteLine("************************************************");

            var carsByBrandIdResult = carManager.GetCarsByBrandId(1);
            if (carsByBrandIdResult.Success)
            {
                foreach (var car in carsByBrandIdResult.Data)
                {
                    Console.WriteLine("CarId: {0} -- Description: {1} -- ModelYear: {2} -- DailyPrice: {3} -- BrandId: {4}",
                                        car.Id, car.Description, car.ModelYear, car.DailyPrice, car.BrandId);
                }
            }
            else
            {
                Console.WriteLine(carsByBrandIdResult.Message);
            }

            Console.WriteLine("************************************************");

            var carsByColorIdResult = carManager.GetCarsByColorId(1);
            if (carsByColorIdResult.Success)
            {
                foreach (var car in carsByColorIdResult.Data)
                {
                    Console.WriteLine("CarId: {0} -- Description: {1} -- ModelYear: {2} -- DailyPrice: {3} -- ColorId: {4}",
                                        car.Id, car.Description, car.ModelYear, car.DailyPrice, car.ColorId);
                }
            }
            else
            {
                Console.WriteLine(carsByColorIdResult.Message);
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

            var carAddedResult1 = carManager.Insert(car2);
            if (carAddedResult1.Success)
            {
                Console.WriteLine(carAddedResult1.Message);
            }
            else
            {
                Console.WriteLine(carAddedResult1.Message);
            }

            Car car3 = new Car()
            {
                BrandId = 1,
                ColorId = 1,
                ModelYear = new DateTime(2020, 1, 1),
                DailyPrice = 1000000,
                Description = "Description of car4",
                Name = "Name of car4"
            };

            var carAddedResult2 = carManager.Insert(car3);
            if (carAddedResult2.Success)
            {
                Console.WriteLine(carAddedResult2.Message);
            }
            else
            {
                Console.WriteLine(carAddedResult2.Message);
            }
        }

        private static void InMemoryCarDalTest()
        {
            // Test of InMemoryCarDal 
            CarManager carManager = new CarManager(new InMemoryCarDal());

            var carsResult = carManager.GetAll();
            if (carsResult.Success)
            {
                foreach (var car in carsResult.Data)
                {
                    Console.WriteLine("CarId: {0} -- Description: {1} -- ModelYear: {2} -- DailyPrice: {3}",
                                        car.Id, car.Description, car.ModelYear, car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(carsResult.Message);
            }

            Console.WriteLine("************************************************");

            var carResult1 = carManager.GetById(1);
            if (carResult1.Success)
            {
                if (carResult1.Data != null)
                    Console.WriteLine("CarId: {0} -- Description: {1} -- ModelYear: {2} -- DailyPrice: {3}",
                                        carResult1.Data.Id, carResult1.Data.Description, carResult1.Data.ModelYear, carResult1.Data.DailyPrice);
            }
            else
            {
                Console.WriteLine(carResult1.Message);
            }
        }
    }
}
