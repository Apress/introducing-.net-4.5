using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifetimeExampleVer1
{
  [Export]
[PartCreationPolicy(CreationPolicy.NonShared)]
 public class RequestListener
{
   private readonly RequestHandler handler;
   [ImportingConstructor]
   public RequestListener(RequestHandler handler)
  {
     this.handler = handler;
  }

  public void HandleRequest()
  {
     Console.WriteLine("{0}: {1}", handler.HandlerName,
     handler.GetDatabaseName ());
   }
}

}
