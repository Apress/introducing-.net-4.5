using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_2_IDE_Fakes
{
    public interface ICustomerRepository
    {
        Customer GetById(int id);
        bool Exists(string email);
        void Delete();
    }
}
