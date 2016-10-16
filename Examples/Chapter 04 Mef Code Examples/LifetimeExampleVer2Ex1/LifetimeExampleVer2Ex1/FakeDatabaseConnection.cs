using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.Composition;

namespace LifetimeExampleVer2Ex1
{
    [Export]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class FakeDatabaseConnection
    {
        private readonly DateTime dateTimeCreated;
        public FakeDatabaseConnection()
        {
            dateTimeCreated = DateTime.Now;
        }

        public string DatabaseName
        {
            get
            {
                return string.Format("Database {0}", dateTimeCreated.Millisecond);
            }
        }
    }
}
