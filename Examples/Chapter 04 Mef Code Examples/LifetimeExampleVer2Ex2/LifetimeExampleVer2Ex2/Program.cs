using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition.Hosting;
using System.Threading;
using System.Reflection;

namespace LifetimeExampleVer2Ex2
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

        /// <summary>
        /// Initializes a new instance of the Program class.
        /// </summary>
        public Program()
        {
			//ComposeWithoutScope();
			ComposeWithScope();

        }

		private void ComposeWithoutScope()
		{
			var global = new TypeCatalog(
						 typeof(RequestHandler),
						 typeof(FakeDatabaseConnection),
						 typeof(RequestListener),
						 typeof(HandlerNameCreator),
						 typeof(Logger),
						 typeof(DataAccessLayer));

			Container = new CompositionContainer(global);
		}

		private void ComposeWithScope()
		{
			var requestLevel = new TypeCatalog(
				typeof(RequestHandler),
				typeof(FakeDatabaseConnection),
				typeof(Logger),
				typeof(DataAccessLayer));

			var listenerLevel = new TypeCatalog(
				typeof(RequestListener),
				typeof(HandlerNameCreator));

			Container = new CompositionContainer(
				new CompositionScopeDefinition(listenerLevel,
							new[] { 
                                new CompositionScopeDefinition(requestLevel, null) 
                            }));
		}
    }
}
