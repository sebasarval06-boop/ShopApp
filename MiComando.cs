
using System;
using System.Windows.Input;

namespace ShopApp
{
    public class MiComando : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool>? _canExecute;

        public MiComando(
            Action execute,
            Func<bool>? canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object? parameter)
        {
            return _canExecute?.Invoke() ?? true;
        }

        public void Execute(object? parameter)
        {
            if (CanExecute(parameter))
            {
                _execute();
            }
        }

        public event EventHandler? CanExecuteChanged;

        public void CambiarEstado()
        {
            CanExecuteChanged?.Invoke(
                this,
                EventArgs.Empty
            );
        }
    }
}
