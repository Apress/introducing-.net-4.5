using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime;
using System.Threading.Tasks;
using System.Windows;

namespace TPLYieldExample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
		protected override void OnStartup(StartupEventArgs e)
		{
			ProfileOptimization.SetProfileRoot(@"c:\profiles");
			ProfileOptimization.StartProfile("myprofile");
			base.OnStartup(e);
		}
    }
}
