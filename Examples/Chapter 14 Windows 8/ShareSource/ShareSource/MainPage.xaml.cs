using System;
using Windows.ApplicationModel.DataTransfer;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ShareSource
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            DataTransferManager.GetForCurrentView().DataRequested += _dataTransferManager_DataRequested;
        }

        private void _dataTransferManager_DataRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
            string textToShare = txtShare.Text;
            DataPackage requestData = args.Request.Data;

            requestData.Properties.Title = "Sharing text for textbox";
            requestData.Properties.Description = textToShare;

            if (!String.IsNullOrEmpty(textToShare))
            {
                requestData.SetText(textToShare);
            }
            else
            {
                args.Request.FailWithDisplayText("Textbox is empty");
            }
        }
    }
}