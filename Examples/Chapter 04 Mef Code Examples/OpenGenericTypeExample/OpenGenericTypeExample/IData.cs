using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenGenericTypeExample
{
    public interface IData<T>
    {
        int Id { get; set; }
        void Update(T source);
    }
}
