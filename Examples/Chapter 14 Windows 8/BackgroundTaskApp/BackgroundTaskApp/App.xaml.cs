using System;
using System.Diagnostics;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Background;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Application template is documented at http://go.microsoft.com/fwlink/?LinkId=234227

namespace BackgroundTaskApp
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            InitializeComponent();
            Suspending += OnSuspending;
            RegisterMaintenanceBackgroundTask();
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used when the application is launched to open a specific file, to display
        /// search results, and so forth.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            // Do not repeat app initialization when already running, just ensure that
            // the window is active
            if (args.PreviousExecutionState == ApplicationExecutionState.Running)
            {
                Window.Current.Activate();
                return;
            }

            if (args.PreviousExecutionState == ApplicationExecutionState.Terminated)
            {
                //TODO: Load state from previously suspended application
            }

            // Create a Frame to act navigation context and navigate to the first page
            var rootFrame = new Frame();
            if (!rootFrame.Navigate(typeof (MainPage)))
            {
                throw new Exception("Failed to create initial page");
            }

            // Place the frame in the current Window and ensure that it is active
            Window.Current.Content = rootFrame;
            Window.Current.Activate();
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            SuspendingDeferral deferral = e.SuspendingOperation.GetDeferral();
            Debug.WriteLine("Suspended at: {0}", DateTime.Now);
            //TODO: Save application state and stop any background activity
            deferral.Complete();
        }

        private bool RegisterMaintenanceBackgroundTask()
        {
            var builder = new BackgroundTaskBuilder
                              {
                                  Name = "Background task",
                                  TaskEntryPoint = "Tasks.BackgroundTask"
                              };
            //IBackgroundTrigger trigger = new MaintenanceTrigger(15, true);
            var trigger = new SystemTrigger(SystemTriggerType.ServicingComplete, false);
            builder.SetTrigger(trigger);
            BackgroundTaskRegistration task = builder.Register();

            task.Progress += task_Progress;
            task.Completed += task_Completed;
            //builder.AddCondition(new SystemCondition(SystemCon));
            //IBackgroundCondition condition = new SystemCondition(SystemConditionType.InternetAvailable);
            //builder.AddCondition(condition);

            return true;
        }

        private void task_Completed(BackgroundTaskRegistration sender, BackgroundTaskCompletedEventArgs args)
        {
            Debug.WriteLine("Task Completed at: {0}", DateTime.Now);
        }

        private void task_Progress(BackgroundTaskRegistration sender, BackgroundTaskProgressEventArgs args)
        {
        }
    }
}