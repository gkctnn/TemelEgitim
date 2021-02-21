using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    //SOLID
    //Open Closed Principle
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new EFProductDal());

            //var products = productManager.GetAll();
            //foreach (var product in products)
            //{
            //    Console.WriteLine(product.ProductName);
            //}

            //var products = productManager.GetAllByCategoryId(1);
            //foreach (var product in products)
            //{
            //    Console.WriteLine(product.ProductName);
            //}

            var products = productManager.GetAllByUnitPrice(30, 36);
            foreach (var product in products)
            {
                Console.WriteLine(product.ProductName);
            }
        }
    }
}
