using System;
using System.ComponentModel;
using System.Windows;

namespace Base.ViewModel
{
    abstract class BaseViewModel : INotifyPropertyChanged
    {
        public BaseViewModel()
        {

        }

        public void ChangeProperty(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public static void UiInvoke(Action a)
        {
            Application.Current.Dispatcher.Invoke(a);
        }
    }
}

