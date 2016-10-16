using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition.Hosting;
using System.Threading;

namespace LifetimeExampleVer2Ex1
{
    class Program
    {
        public CompositionContainer Container { get; set; }
    
        static void Main(string[] args)
        {
            var p = new Program();
            var listener = p.Container.GetExportedValue<RequestListener>();
            for (int i = 0; i < 3; i++)
            {
                listener.HandleRequest();
                Console.WriteLine();
                Thread.Sleep(1000);
            }

            Console.ReadKey();
        }

        public Program()
        {
            var global = new TypeCatalog(
                typeof(RequestHandler), 
                typeof(FakeDatabaseConnection), 
                typeof(HandlerNameCreator), 
                typeof(RequestListener));

            Container = new CompositionContainer(global);
        }
    }
}
