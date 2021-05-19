using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DL.interfaces
{
    public interface IBaseDL<T>
    {
        IEnumerable<T> GetAll();
        T GetById(Guid id);
        int Insert(T entity);
        int Update(T entity);
        int Delete(Guid id);
    }
}
