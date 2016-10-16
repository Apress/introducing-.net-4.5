using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;

namespace LifetimeExampleVer1
{
    [Export]
    public class HandlerNameCreator
    {
        int counter = 0;
        string prefix = "Handler";

        public string GetAhandlerName()
        {
            counter += 1;
            return string.Format("{0} {1}", prefix, counter);
        }
    }
}
