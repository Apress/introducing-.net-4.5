using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;

namespace LifetimeExampleVer1
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
            HandlerName = nameCreator.GetAhandlerName();
            this.dbConnection = dbConnection;
        }

        public string GetDatabaseName()
        {
            return this.dbConnection.DatabaseName;
        }


    }
}
