using System;
using System.Windows.Input;

namespace DemoCenter.Maui.ViewModels {
    public class DelegateCommand : ICommand {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        public DelegateCommand(Action execute) : this(execute, null) { }

        public DelegateCommand(Action execute, Func<bool> canExecute) {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter) {
            if(_canExecute != null)
                return _canExecute();
            return true;
        }

        public void Execute(object parameter) {
            _execute();
        }

        public void RaiseCanExecuteChanged() {
            var tmpHandle = CanExecuteChanged;
            if(tmpHandle != null)
                tmpHandle(this, new EventArgs());
        }

        public event EventHandler CanExecuteChanged;
    }
    public class DelegateCommand<T> : ICommand {
        private readonly Action<T> _execute;
        private readonly Func<T, bool> _canExecute;

        public DelegateCommand(Action<T> execute) : this(execute, null) { }

        public DelegateCommand(Action<T> execute, Func<T, bool> canExecute) {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter) {
            if(_canExecute != null)
                return _canExecute((T)parameter);

            return true;
        }

        public void Execute(object parameter) {
            _execute((T)parameter);
        }

        public void RaiseCanExecuteChanged() {
            var tmpHandle = CanExecuteChanged;
            if(tmpHandle != null)
                tmpHandle(this, new EventArgs());
        }

        public event EventHandler CanExecuteChanged;
    }
}
