using System;
using System.ComponentModel;
using System.Windows;

namespace WpfStaticPropertyBinding
{

    public class MyClass
    {
        private static string _myProperty;
        public static string MyProperty
        {
            get { return _myProperty; }
            set 
            { 
                _myProperty = value;
                OnStaticPropertyChanged("MyProperty");
            }
        }

        private static EventHandler<PropertyChangedEventArgs> StaticPropertyChanged;
        public static void OnStaticPropertyChanged(string propertyName)
        {
            var handler = StaticPropertyChanged;
            if (handler != null) handler(null, new PropertyChangedEventArgs(propertyName));
        }
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MyClass();

            //BindingExpression bindingExpression = BindingOperations.GetBindingExpression(MyTextBox, TextBlock.TextProperty);

            //var target = bindingExpression.Target;
            //target.SetValue("abcd");

            //var targetProperty = bindingExpression.TargetProperty;
            //var name = targetProperty.Name;


        }
    }
}
