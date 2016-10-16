using System.ComponentModel;
using System.Windows;

namespace WpfDataBindingWait
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

    }

public class Person : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        var handler = PropertyChanged;
        if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
    }

    private string _name;
    public string Name
    {
        get  { return _name; }
        set 
        { 
            _name = value;
            OnPropertyChanged("Name");
        }

    }
}
}
