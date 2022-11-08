using BusinessLayer.Abstract;
using DAL.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class TitleManager : ITitleService
    {
        ITitleDal _titleDal;

        public TitleManager(ITitleDal titleDal)
        {
            _titleDal = titleDal;
        }

        public Title GetByID(int id)
        {
            return _titleDal.Get(x => x.ID == id);
        }

        public void TDelete(Title t)
        {
            _titleDal.Delete(t);
        }

        public void TInsert(Title t)
        {
            _titleDal.Insert(t);
        }

        public List<Title> TList()
        {
            return _titleDal.List();
        }

        public List<Title> TList(Expression<Func<Title, bool>> filter)
        {
            return _titleDal.List(filter);
        }

        public void TUpdate(Title t)
        {
            _titleDal.Update(t);
        }
    }
}
