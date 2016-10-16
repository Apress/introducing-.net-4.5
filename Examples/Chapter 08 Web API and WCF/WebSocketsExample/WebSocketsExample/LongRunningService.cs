using System.ServiceModel;
using System.Threading;

namespace WebSocketsExample
{
    [ServiceContract(CallbackContract = typeof (IProgressCallbackService))]
    public interface ILongRunningService
    {
        [OperationContract(IsOneWay = true)]
        void DoLongRunningOperation();
    }

    [ServiceContract]
    public interface IProgressCallbackService
    {
        [OperationContract]
        void UpdateProgress(int percentageComplete);
    }

    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant)]
    public class LongRunningService : ILongRunningService
    {
        #region ILongRunningService Members

        public void DoLongRunningOperation()
        {
            for (int i = 0; i <= 100; i += 10)
            {
                Thread.Sleep(1000);
                try
                {
                    OperationContext.Current.GetCallbackChannel<IProgressCallbackService>().
                        UpdateProgress(i);
                }
                catch (CommunicationException)
                {
                    //Ignore communication exception in this simple implementation
                    //Handles the client closing down the connection
                }
            }
        }

        #endregion
    }
}