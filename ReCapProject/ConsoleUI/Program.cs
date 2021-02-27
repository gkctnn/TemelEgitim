using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Reflection;
using System.Threading;

namespace ConsoleUI
{
    public delegate void MyDelegate();
    public delegate void MyDelegate2(string text);
    public delegate int MyDelegate3(int number1, int number2);

    class Program
    {
        static void Main(string[] args)
        {
            //InMemoryCarDalTest();

            //EFCarDalTest();

            //EFCarDtoTest();

            //Reflection();

            //Delegates();

            Func();
        }

        private static void Func()
        {
            Matematik matematik = new Matematik();
            Console.WriteLine(matematik.Topla(5, 6));

            Func<int, int, int> add = matematik.Topla;
            Console.WriteLine(add(10, 12));

            Func<int> getRandomNumber = delegate ()
            {
                Random random = new Random();
                return random.Next(1, 100);
            };
            Console.WriteLine(getRandomNumber());

            Thread.Sleep(1000);

            Func<int> getRandomNumber2 = () => new Random().Next(1, 100);
            Console.WriteLine(getRandomNumber2());
        }

        private static void Delegates()
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.SendMessage();
            customerManager.ShowAlert();

            MyDelegate myDelegate = customerManager.SendMessage;
            myDelegate += customerManager.ShowAlert;
            myDelegate -= customerManager.SendMessage;
            myDelegate();

            MyDelegate2 myDelegate2 = customerManager.SendMessage2;
            myDelegate2 += customerManager.ShowAlert2;
            myDelegate2("Hello");

            Matematik matematik = new Matematik();
            MyDelegate3 myDelegate3 = matematik.Topla;
            myDelegate3 += matematik.Carp;
            Console.WriteLine(myDelegate3(2, 3));

            Console.ReadLine();
        }

        private static void Reflection()
        {
            DortIslem dortIslem = new DortIslem(2, 3);
            Console.WriteLine(dortIslem.Topla2());
            Console.WriteLine(dortIslem.Topla(3, 4));

            var tip = typeof(DortIslem);
            DortIslem dortIslem2 = (DortIslem)Activator.CreateInstance(tip, 4, 6);
            Console.WriteLine(dortIslem2.Topla2());
            Console.WriteLine(dortIslem2.Topla(6, 8));

            var instance = Activator.CreateInstance(tip, 8, 12);
            MethodInfo methodInfo = instance.GetType().GetMethod("Topla2");
            Console.WriteLine(methodInfo.Invoke(instance, null));

            var methodlar = tip.GetMethods();
            foreach (var info in methodlar)
            {
                Console.WriteLine("Method Adı: {0}", info.Name);

                foreach (var parameter in info.GetParameters())
                {
                    Console.WriteLine("Parametre Adı: {0}", parameter.Name);
                }

                foreach (var attribute in info.GetCustomAttributes())
                {
                    Console.WriteLine("Attribute Adı: {0}", attribute.GetType().Name);
                }

                Console.WriteLine("");
            }

            Console.ReadLine();
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

    public class DortIslem
    {
        private int _sayi1;
        private int _sayi2;

        public DortIslem(int sayi1, int sayi2)
        {
            _sayi1 = sayi1;
            _sayi2 = sayi2;
        }

        public int Topla(int sayi1, int sayi2)
        {
            return sayi1 + sayi2;
        }

        public int Carp(int sayi1, int sayi2)
        {
            return sayi1 * sayi2;
        }

        public int Topla2()
        {
            return _sayi1 + _sayi2;
        }

        [MethodName("Carpma")]
        public int Carp2()
        {
            return _sayi1 * _sayi2;
        }
    }

    class MethodNameAttribute : Attribute
    {
        public MethodNameAttribute(string name)
        {

        }
    }

    public class CustomerManager
    {
        public void SendMessage()
        {
            Console.WriteLine("Hello!");
        }
        public void ShowAlert()
        {
            Console.WriteLine("Be Careful!");
        }
        public void SendMessage2(string message)
        {
            Console.WriteLine(message);
        }
        public void ShowAlert2(string alert)
        {
            Console.WriteLine(alert);
        }
    }

    public class Matematik
    {
        public int Topla(int sayi1, int sayi2)
        {
            return sayi1 + sayi2;
        }
        public int Carp(int sayi1, int sayi2)
        {
            return sayi1 * sayi2;
        }
    }
}
