﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstract
{
   public interface IGenericDal<T>
    {
        List<T> List();
        void Insert(T t);
        void Delete(T t);
        void Update(T t);
        List<T> List(Expression<Func<T, bool>> filter);
    }
}
