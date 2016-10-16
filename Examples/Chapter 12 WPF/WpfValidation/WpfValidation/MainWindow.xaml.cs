using System.Collections;
using System.Windows;

namespace WpfValidation
{



    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new Person() {Name = "Fred Nurk"};
        }
    }
}
