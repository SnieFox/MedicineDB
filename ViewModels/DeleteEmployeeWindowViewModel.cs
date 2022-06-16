using MedicineDB.Commands;
using MedicineDB.Entity.Tables;
using MedicineDB.Model;
using MedicineDB.Model.Entities;
using MedicineDB.View;
using MedicineDB.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MedicineDB.ViewModels
{
    internal class DeleteEmployeeWindowViewModel : ViewModel
    {
        public DeleteEmployeeWindowViewModel()
        {
            DeleteEmployee = new RelayCommand(OnDeleteEmployeeExecute, CanDeleteEmployeeExecute);
        }


        //Поле Id DeleteEmployeeWindowWiewModel
        private int _Id;
        public int Id
        {
            get => _Id;
            set
            {
                _Id = value;
                OnPropertyChanged();
            }
        }
        //Команда удаления сотрудника
        public RelayCommand DeleteEmployee { get; }
        private bool CanDeleteEmployeeExecute(object arg) => true;
        private void OnDeleteEmployeeExecute(object obj)
        {
            User.DeleteEmployeeMethod(User.GetEmployeeById(Id));
            OnPropertyChanged();
        }
        public event PropertyChangedEventHandler? PropertyChanged;
    }

}
