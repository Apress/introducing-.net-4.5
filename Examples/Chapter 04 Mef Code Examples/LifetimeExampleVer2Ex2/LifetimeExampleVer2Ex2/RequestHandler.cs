using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;

namespace LifetimeExampleVer2Ex2
{

    [Export]
     public class RequestHandler
    {
        private DataAccessLayer dataAccessLayer;
        private Logger logger;
        public string HandlerName { get; private set; }

      [ImportingConstructor]
        public RequestHandler(DataAccessLayer dataAccessLayer, Logger logger, HandlerNameCreator nameCreator)
        {
            HandlerName = nameCreator.GetAhandlerNme();
            this.dataAccessLayer = dataAccessLayer;
            this.logger = logger;
        }

        public string GetRequestHandlerInfo()
        {
            var sb = new StringBuilder();
            sb.AppendLine(HandlerName);
            sb.AppendLine(dataAccessLayer.DataAccessLayerInfo(HandlerName));
            sb.AppendLine(logger.LoggerInfo(HandlerName));
            return sb.ToString();
        }
    }
}
