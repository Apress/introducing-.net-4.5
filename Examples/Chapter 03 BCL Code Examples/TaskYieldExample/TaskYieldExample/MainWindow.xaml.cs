using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace TPLYieldExample
{
  
    public partial class MainWindow : Window
    {
		
        public MainWindow()
        {
			
            InitializeComponent();
			
			Debug.WriteLine("Starting thread {0}",Thread.CurrentThread.ManagedThreadId);
        }

        private  void  GetStuffButton_Click(object sender, RoutedEventArgs e)
        {
			Dispatcher.InvokeAsync(async () =>
			   {
                  for (int i = 0; i < 10000; i++)
                   {
                       Debug.WriteLine("Dispatcher Thread: {0}", Dispatcher.CurrentDispatcher.Thread.ManagedThreadId);
                       var result =  Process(i);
                       ListOfThings.Items.Add(result);
                       
                       await Task.Yield();
                   }
               }, DispatcherPriority.Background);
        }
        private string Process(int i)
        {
			Debug.WriteLine("Process() Thread: {0}",Thread.CurrentThread.ManagedThreadId);
			Thread.Sleep(10);
			
            return string.Format("Thing {0}", i);
        }
    }
}
