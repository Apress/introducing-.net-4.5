using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;

namespace LifetimeExampleVer2Ex1
{

    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
     public class RequestHandler
    {
        readonly FakeDatabaseConnection dbConnection;
        public string HandlerName { get; private set; }

      [ImportingConstructor]
        public RequestHandler(FakeDatabaseConnection dbConnection, HandlerNameCreator nameCreator)
        {
            HandlerName = nameCreator.GetAHandlerName();
            this.dbConnection = dbConnection;
        }

        public string GetDatabaseName()
        {
            return dbConnection.DatabaseName;
        }
    }
}
