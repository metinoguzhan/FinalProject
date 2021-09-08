using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _category;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _category = categoryDal;
        }

        public List<Category> GetAll()
        {
            return _category.GetAll();
        }

        public Category GetById(int categoryId)
        {
            return _category.Get(p => p.CategoryId == categoryId);
        }
    }
}
