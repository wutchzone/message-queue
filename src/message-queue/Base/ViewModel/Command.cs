using System;

namespace Base.ViewModel
{
    class Command : BaseCommand
    {
        protected Action<object> _execute;

        public Command(Action<object> execute): this(execute, DefaultCanExecute)
        {
        }


        public Command(Action<object> execute, Predicate<object> canExecute) : base(canExecute)
        {
            this._execute = execute ?? throw new ArgumentNullException("Execute property is not set.");
        }

        override public void Execute(object parameter)
        {
            this._execute(parameter);
        }

        public void Destroy()
        {
            this._canExecute = _ => false;
            this._execute = _ => { return; };
        }
    }
}
