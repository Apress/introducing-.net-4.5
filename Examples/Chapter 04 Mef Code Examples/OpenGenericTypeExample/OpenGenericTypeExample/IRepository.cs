using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenGenericTypeExample
{
    public interface IRepository<T>
    {
        T FindById(int id);
        void Save(T item);
    }
}
