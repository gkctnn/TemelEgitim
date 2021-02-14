using GameProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace GameProject.Abstract
{
    public class ProductManager : IProductService
    {
        public void Add(Product product)
        {
            Console.WriteLine("Add Product");
        }

        public void Delete(Product product)
        {
            Console.WriteLine("Delete Product");
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            Console.WriteLine("Get Product");

            return new Product();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            Console.WriteLine("Get Products");

            return new List<Product>();
        }

        public void Update(Product product)
        {
            Console.WriteLine("Update Product");
        }
    }
}
