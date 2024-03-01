using System;
using System.Windows.Input;

namespace Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.core
{
    internal class RelayCommand : ICommand
    {
        private Action<object> _execute;
        private Func<object, bool> _canExecute;

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute != null || _canExecute(parameter); 
        }

        public void Execute(object parameter)
        {
            _canExecute(parameter);
        }
    }
}
