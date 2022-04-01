using System;

namespace MedicineDB.Commands
{
    internal interface ICommand
    {
        event EventHandler CanExecuteChanged;
        void Execute(object parameter);
        bool CanExecute(object parameter);
    }
}
