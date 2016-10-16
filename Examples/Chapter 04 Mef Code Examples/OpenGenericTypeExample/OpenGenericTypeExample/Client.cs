using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenGenericTypeExample
{
    public class Client : IData<Client>
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }


        public void Update(Client source)
        {
            CompanyName = source.CompanyName;
            ContactName = source.ContactName;
        }
    }
}
