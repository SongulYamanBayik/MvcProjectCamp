using BusinessLayer.Abstract;
using DAL.Abstract;
using DAL.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void TDelete(Category t)
        {
            _categoryDal.Delete(t);
        }

        public void TInsert(Category t)
        {
            _categoryDal.Insert(t);
        }

        public List<Category> TList()
        {
            return _categoryDal.List();
        }

        public List<Category> TList(Expression<Func<Category, bool>> filter)
        {
            return _categoryDal.List(filter);
        }

        public void TUpdate(Category t)
        {
            _categoryDal.Update(t);
        }
    }
}
