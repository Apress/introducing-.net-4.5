using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;

namespace LifetimeExampleVer2Ex2
{
    [Export]
    public class RequestListener
    {
        ExportFactory<RequestHandler> factory;

        [ImportingConstructor]
        public RequestListener(ExportFactory<RequestHandler> factory)
        {
            this.factory = factory;
        }

        public void HandleRequest()
        {
            using(var instance = factory.CreateExport())
            {
                var handler = instance.Value;
                Console.WriteLine(handler.GetRequestHandlerInfo());
            }
        }
    }
}
