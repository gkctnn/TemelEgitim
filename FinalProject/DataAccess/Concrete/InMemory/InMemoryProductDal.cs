using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        private readonly List<Product> _products;

        public InMemoryProductDal()
        {
            _products = new List<Product>
            {
                new Product
                {
                    ProductId=1,
                    CategoryId=1,
                    ProductName="Bardak",
                    UnitsInStock=15,
                    UnitPrice=15
                },
                new Product
                {
                    ProductId=2,
                    CategoryId=1,
                    ProductName="Kamera",
                    UnitsInStock=3,
                    UnitPrice=500
                },
                new Product
                {
                    ProductId=3,
                    CategoryId=1,
                    ProductName="Telefon",
                    UnitsInStock=2,
                    UnitPrice=1500
                },
                new Product
                {
                    ProductId=4,
                    CategoryId=1,
                    ProductName="Klavye",
                    UnitsInStock=65,
                    UnitPrice=150
                },
                new Product
                {
                    ProductId=5,
                    CategoryId=1,
                    ProductName="Fare",
                    UnitsInStock=1,
                    UnitPrice=85
                }
            };
        }

        public void Add(Product entity)
        {
            _products.Add(entity);
        }

        public void Delete(Product entity)
        {
            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == entity.ProductId);

            _products.Remove(productToDelete);

            //foreach (var p in _products)
            //{
            //    if (product.ProductId == p.ProductId)
            //    {
            //        productToDelete = p;
            //    }
            //}
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }
        
        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            return _products;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == entity.ProductId);

            productToUpdate.ProductName = entity.ProductName;
            productToUpdate.CategoryId = entity.CategoryId;
            productToUpdate.UnitPrice = entity.UnitPrice;
            productToUpdate.UnitsInStock = entity.UnitsInStock;
        }
    }
}
