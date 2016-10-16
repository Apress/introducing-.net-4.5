using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;

namespace LifetimeExampleVer2Ex2
{
    [Export]
    public class Logger
    {
        FakeDatabaseConnection dbConnection;
        private string loggerId;
        
        [ImportingConstructor]
               public Logger(FakeDatabaseConnection dbConnection)
        {
            this.dbConnection = dbConnection;
            loggerId = string.Format("Logger {0}",DateTime.Now.Millisecond);
        }

        public string LoggerInfo(string handlerName)
        {
            return string.Format("{0} using {1}", 
                       loggerId, 
                       dbConnection.DatabaseName);
        }
    }
}
