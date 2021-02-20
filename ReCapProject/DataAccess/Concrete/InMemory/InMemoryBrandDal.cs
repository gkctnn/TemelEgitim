using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryBrandDal : IBrandDal
    {
        List<Brand> _brands;

        public InMemoryBrandDal()
        {
            _brands = new List<Brand>
            {
                new Brand
                {
                    Name="Bmw"
                }
            };
        }

        public void Add(Brand brand)
        {
            Brand _brand = _brands.SingleOrDefault(b => b.Id == brand.Id);

            if (_brand == null)
            {
                _brands.Add(brand);
            }
        }

        public void Delete(Brand brand)
        {
            Brand brandToDelete = _brands.SingleOrDefault(b => b.Id == brand.Id);

            if (brandToDelete != null)
            {
                _brands.Remove(brandToDelete);
            }
        }

        public List<Brand> GetAll()
        {
            return _brands;
        }

        public void Update(Brand brand)
        {
            Brand brandToUpdate = _brands.SingleOrDefault(b => b.Id == brand.Id);

            if (brandToUpdate != null)
            {
                brandToUpdate.Name = brand.Name;
            }
        }
    }
}
