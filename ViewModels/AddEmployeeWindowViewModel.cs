using MedicineDB.Commands;
using MedicineDB.Entity.Tables;
using MedicineDB.Model;
using MedicineDB.Model.Models;
using MedicineDB.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicineDB.ViewModels
{
    internal class AddEmployeeWindowViewModel : ViewModel
    {
        public AddEmployeeWindowViewModel()
        {
            AddEmployee = new RelayCommand(OnAddEmployeeExecute, CanAddEmployeeExecute);
        }

        //Поле Id DeleteEmployeeWindowWiewModel
        private string _SurName;
        public string SurName
        {
            get => _SurName;
            set
            {
                _SurName = value;
                OnPropertyChanged();
            }
        }
        //Поле Id DeleteEmployeeWindowWiewModel
        private string _Name;
        public string Name
        {
            get => _Name;
            set
            {
                _Name = value;
                OnPropertyChanged();
            }
        }
        //Поле Id DeleteEmployeeWindowWiewModel
        private string _Patronymic;
        public string Patronymic
        {
            get => _Patronymic;
            set
            {
                _Patronymic = value;
                OnPropertyChanged();
            }
        }
        //ComboBox Specialities
        private List<string> specialitiesComboBox = DbUsage.GetSpecialities();
        public List<string> SpecialityTextBox
        {
            get => specialitiesComboBox;
            set
            {
                specialitiesComboBox = value;
                OnPropertyChanged();
            }
        }
        //Выбранный элемент ComboBox Specialities
        private string specialitiesItem;
        public string SpecialitiesItem
        {
            get => specialitiesItem;
            set
            {
                specialitiesItem = value;
                OnPropertyChanged();
            }
        }
        //ComboBox Workplaces
        private List<string> workplaceComboBox = DbUsage.GetWorkplace();
        public List<string> WorkplaceTextBox
        {
            get => workplaceComboBox;
            set
            {
                workplaceComboBox = value;
                OnPropertyChanged();
            }
        }

        //Выбранный элемент ComboBox Workplaces
        private string workplaceItem;
        public string WorkplaceItem
        {
            get => workplaceItem;
            set
            {
                workplaceItem = value;
                OnPropertyChanged();
            }
        }

        //Команда Добавления сотрудника
        public RelayCommand AddEmployee { get; }
        private bool CanAddEmployeeExecute(object arg) => true;
        private void OnAddEmployeeExecute(object obj)
        {
            User.CreateEmployee(DbUsage.GetWorkplaceByName(WorkplaceItem), DbUsage.GetSpecialitByName(SpecialitiesItem), SurName, Name, Patronymic);
            DbUsage dbUsage = new DbUsage();
            dbUsage.ViewRefreshMethod();
            OnPropertyChanged();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
