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
    public class WriterManager : IWriterService
    {
        IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public Writer GetByID(int id)
        {
            return _writerDal.Get(x=>x.ID==id);
        }

        public void TDelete(Writer t)
        {
            _writerDal.Delete(t);
        }

        public void TInsert(Writer t)
        {
            _writerDal.Insert(t);
        }

        public List<Writer> TList()
        {
            return _writerDal.List();
        }

        public List<Writer> TList(Expression<Func<Writer, bool>> filter)
        {
            return _writerDal.List(filter);
        }

        public void TUpdate(Writer t)
        {
            _writerDal.Update(t);
        }
    }
}
