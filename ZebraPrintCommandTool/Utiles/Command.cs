﻿using System;
using System.Windows.Input;

namespace ZebraPrintCommandTool.Utiles
{
    public class Command : ICommand
    {
        Action<object> ExecuteMethod;
        Func<object, bool> CanexecuteMethod;

        public Command(Action<object> execute_Method)
        {
            this.ExecuteMethod = execute_Method;
        }
        private Command(Action<object> execute_Method, Func<object, bool> canexecute_Method)
        {
            this.ExecuteMethod = execute_Method;
            this.CanexecuteMethod = canexecute_Method;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ExecuteMethod(parameter);
        }
    }
}
