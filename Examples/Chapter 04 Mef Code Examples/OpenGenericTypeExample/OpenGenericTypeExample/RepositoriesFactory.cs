using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;

namespace OpenGenericTypeExample
{
    public class RepositoriesFactory
    {
        [Import(typeof(IRepository<>))]
        public IRepository<Client> Clients { get; set; }

        [Import(typeof(IRepository<>))]
        public IRepository<Project> Projects { get; set; }
       
        public RepositoriesFactory()
        {
            var assemblyCatalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            var container = new CompositionContainer(assemblyCatalog);
          
            container.ComposeParts(this);
        }
    }
}
 