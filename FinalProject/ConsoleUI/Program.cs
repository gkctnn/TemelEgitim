﻿using Business.Concrete;
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
            ProductTest();

            //CategoryTest();
        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

            var categories = categoryManager.GetAll();
            foreach (var category in categories)
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());

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

            //var products = productManager.GetAllByUnitPrice(30, 36);
            //foreach (var product in products)
            //{
            //    Console.WriteLine(product.ProductName);
            //}

            var result = productManager.GetProductDetails();
            if (result.Success)
            {
                foreach (var product in result.Data)
                {
                    Console.WriteLine(product.ProductName + " / " + product.CategoryName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}
