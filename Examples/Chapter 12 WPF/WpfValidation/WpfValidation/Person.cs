using System;
using System.Collections;
using System.ComponentModel;
using System.Threading;

namespace WpfValidation
{
    //public class Person : INotifyPropertyChanged, IDataErrorInfo
    //{
    //    public event PropertyChangedEventHandler PropertyChanged;

    //    protected virtual void OnPropertyChanged(string propertyName)
    //    {
    //        var handler = PropertyChanged;
    //        if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
    //    }

    //    private string _name;
    //    public string Name
    //    {
    //        get { return _name; }
    //        set
    //        {
    //            _name = value;
    //            OnPropertyChanged("Name");
    //        }

    //    }

    //    public string this[string columnName]
    //    {
    //        get
    //        {
    //            if (columnName == "Name")
    //            {
    //                if (string.IsNullOrEmpty(Name))
    //                {
    //                    Thread.Sleep(5000);
    //                    return "Name cannot be empty";
    //                }
    //            }
    //            return String.Empty;
    //        }
    //    }

    //    public string Error { get { return string.Empty; } }
    //}

    public class Person : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
            OnErrorsChanged(propertyName);
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                HasErrors = (string.IsNullOrEmpty(value));
                OnPropertyChanged("Name");
            }

        }

        public IEnumerable GetErrors(string propertyName)
        {
            Thread.Sleep(5000);
            if (propertyName == "Name")
            {
                if (string.IsNullOrEmpty(Name))
                {
                    return "Name cannot be empty";
                }
            }
            return String.Empty;
        }

        public bool HasErrors { get; private set; }
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public void OnErrorsChanged(string propertyName)
        {
            var handler = ErrorsChanged;
            if (handler != null) handler(this, new DataErrorsChangedEventArgs(propertyName));

        }

    }
}