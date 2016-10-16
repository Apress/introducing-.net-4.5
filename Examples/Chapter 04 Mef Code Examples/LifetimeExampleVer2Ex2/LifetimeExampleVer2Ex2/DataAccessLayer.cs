using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;

namespace LifetimeExampleVer2Ex2
{
    [Export]
    public class DataAccessLayer
    {
        private string dabId;
        FakeDatabaseConnection dbConnection;

        [ImportingConstructor]
        public DataAccessLayer(FakeDatabaseConnection dbConnection)
        {
            this.dbConnection = dbConnection;
            dabId = string.Format("Data Access Layer {0}", DateTime.Now.Millisecond);
        }

        public string DataAccessLayerInfo(string handlerName)
        {
            return string.Format("{0} using {1}", 
                       dabId, 
                       dbConnection.DatabaseName);
        }
    }
}
