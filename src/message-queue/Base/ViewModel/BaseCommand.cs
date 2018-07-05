using System;
using System.Windows.Input;

namespace Base.ViewModel
{
    abstract class BaseCommand : ICommand
    {
        protected Predicate<object> _canExecute;
        protected event EventHandler CanExecuteChangedInternal;

        public BaseCommand(Predicate<object> canExecute)
        {
            _canExecute = canExecute ?? throw new ArgumentNullException("Property canExecute is not set.");
        }

        public BaseCommand() : this(DefaultCanExecute) { }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
                this.CanExecuteChangedInternal += value;
            }

            remove
            {
                CommandManager.RequerySuggested -= value;
                this.CanExecuteChangedInternal -= value;
            }
        }

        protected void OnCanExecuteChanged()
        {
            EventHandler handler = this.CanExecuteChangedInternal;
            if (handler != null)
            {
                handler.Invoke(this, EventArgs.Empty);
            }
        }

        protected static bool DefaultCanExecute(object parameter)
        {
            return true;
        }

        virtual public bool CanExecute(object parameter)
        {
            return this._canExecute != null && this._canExecute(parameter);
        }

        virtual public void Execute(object parameter) { }
    }
}
