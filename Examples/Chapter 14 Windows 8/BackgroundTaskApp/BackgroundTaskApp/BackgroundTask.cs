using System;
using System.Diagnostics;
using Windows.ApplicationModel.Background;
using Windows.Storage;
using Windows.System.Threading;

namespace BackgroundTaskApp
{
    public sealed class BackgroundTask : IBackgroundTask
    {
        private volatile bool _cancelRequested;
        private BackgroundTaskDeferral _deferral;
        private ThreadPoolTimer _periodicTimer;
        private uint _progress;
        private IBackgroundTaskInstance _taskInstance;

        // 
        // The Run method is the entry point of a background task. 
        // 

        #region IBackgroundTask Members

        public void Run(IBackgroundTaskInstance taskInstance)
        {
            Debug.WriteLine("Background " + taskInstance.Task.Name + " Starting...");

            // 
            // Associate a cancellation handler with the background task. 
            // 
            taskInstance.Canceled += OnCanceled;

            // 
            // Get the deferral object from the task instance, and take a reference to the taskInstance; 
            // 
            _deferral = taskInstance.GetDeferral();
            _taskInstance = taskInstance;

            _periodicTimer = ThreadPoolTimer.CreatePeriodicTimer(PeriodicTimerCallback, TimeSpan.FromMilliseconds(500));
        }

        #endregion

        // 
        // Handles background task cancellation. 
        // 
        private void OnCanceled(IBackgroundTaskInstance sender, BackgroundTaskCancellationReason reason)
        {
            // 
            // Indicate that the background task is canceled. 
            // 
            _cancelRequested = true;

            Debug.WriteLine("Background " + sender.Task.Name + " Cancel Requested...");
        }

        // 
        // Simulate the background task activity. 
        // 
        private void PeriodicTimerCallback(ThreadPoolTimer timer)
        {
            if ((_cancelRequested == false) && (_progress < 100))
            {
                _progress += 10;
                _taskInstance.Progress = _progress;
            }
            else
            {
                _periodicTimer.Cancel();

                ApplicationDataContainer settings = ApplicationData.Current.LocalSettings;
                string key = _taskInstance.Task.Name;

                // 
                // Write to LocalSettings to indicate that this background task ran. 
                // 
                if (_cancelRequested)
                {
                    settings.Values[key] = "Canceled";
                }
                else
                {
                    settings.Values[key] = "Completed";
                }

                Debug.WriteLine("Background " + _taskInstance.Task.Name +
                                (_cancelRequested ? " Canceled" : " Completed"));

                // 
                // Indicate that the background task has completed. 
                // 
                _deferral.Complete();
            }
        }

        //public async void Run(IBackgroundTaskInstance taskInstance)
        //{
        //    taskInstance.Canceled += taskInstance_Canceled;

        //    //var deferral = taskInstance.GetDeferral();
        //    doLongRunningOperation();
        //    //deferral.Complete();


        //}

        //private void doLongRunningOperation()
        //{
        //    //return new Task(() =>
        //                        {
        //                            var i = 0;
        //                            while (i++ < 10)
        //                            {
        //                                //Task.Delay(1000);
        //                                Debug.WriteLine("Executing {0} at {1}", i, DateTime.Now);
        //                            }
        //                        }
        //    //);

        //}

        //void taskInstance_Canceled(IBackgroundTaskInstance sender, BackgroundTaskCancellationReason reason)
        //{
        //    //Handle cancelling
        //}
    }
}