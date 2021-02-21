using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCategoryDal : ICategoryDal
    {
        List<Category> _categories;

        public InMemoryCategoryDal()
        {
            _categories = new List<Category>
            {
                new Category
                {
                    CategoryId=1,
                    CategoryName="Teknoloji"
                }
            };
        }

        public void Add(Category category)
        {
            _categories.Add(category);
        }

        public void Delete(Category category)
        {
            var categoryToDelete = _categories.SingleOrDefault(c => c.CategoryId == category.CategoryId);

            _categories.Remove(categoryToDelete);
        }

        public Category Get(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }
        
        public List<Category> GetAll(Expression<Func<Category, bool>> filter = null)
        {
            return _categories;
        }

        public void Update(Category category)
        {
            var categoryToUpdate = _categories.SingleOrDefault(c => c.CategoryId == category.CategoryId);

            categoryToUpdate.CategoryName = category.CategoryName;
        }
    }
}
