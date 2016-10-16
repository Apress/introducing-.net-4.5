using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;

namespace LifetimeExampleVer2Ex1
{
    [Export]
    public class RequestListener
    {
        private readonly ExportFactory<RequestHandler> factory;

        [ImportingConstructor]
        public RequestListener(ExportFactory<RequestHandler> factory)
        {
            this.factory = factory;
        }

        public void HandleRequest()
        {
            using (var instance = factory.CreateExport())
            {
                var handler = instance.Value;
                Console.WriteLine("{0}: {1}", 
                    handler.HandlerName, 
                    handler.GetDatabaseName());
            }
        }
    }
}
