using System;
using System.Windows.Input;

namespace KeyLoggerWpf.Commands
{
    public class CommonCommand: ICommand
    {
        private readonly Action execute;
        private readonly Func<bool> canExecute;

        public CommonCommand(Action execute):this(execute, null) { }

        public CommonCommand(Action execute, Func<bool> canExecute)
        {
            this.execute = execute;

            if(canExecute==null)
            {
                canExecute = ()=>true;
            }

            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute();
        }

        public void Execute(object parameter)
        {
            execute();
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (canExecute != null)
                {
                    CommandManager.RequerySuggested += value;
                }
            }
            remove
            {
                if (canExecute != null)
                {
                    CommandManager.RequerySuggested -= value;
                }
            }
        }

         
    }
}
