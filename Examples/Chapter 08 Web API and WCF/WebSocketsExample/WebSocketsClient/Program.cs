using System;
using System.ServiceModel;
using WebSocketsClient.ServiceReference1;

namespace WebSocketsClient
{
    internal class CallbackContract : ILongRunningServiceCallback
    {
        #region ILongRunningServiceCallback Members

        public void UpdateProgress(int percentageComplete)
        {
            Console.WriteLine("Progress indicator: {0}", percentageComplete);
        }

        #endregion
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            var callbackContext = new InstanceContext(new CallbackContract());
            var proxy = new LongRunningServiceClient(callbackContext);
            proxy.DoLongRunningOperation();
            Console.ReadLine();
        }
    }
}