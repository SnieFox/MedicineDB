using MedicineDB.Commands;
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
    internal class EditEmployeeWindowViewModel : ViewModel
    {
        public EditEmployeeWindowViewModel()
        {
            EditEmployee = new RelayCommand(OnEditEmployeeExecute, CanEditEmployeeExecute);
        }
        //Поле Id EditEmployeeWindowWiewModel
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

        //Поле SurName EditEmployeeWindowWiewModel
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
        //Поле Name EditEmployeeWindowWiewModel
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
        //Поле Patronymic EditEmployeeWindowWiewModel
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
        public RelayCommand EditEmployee { get; }
        private bool CanEditEmployeeExecute(object arg) => true;
        private void OnEditEmployeeExecute(object obj)
        {
            User.EditEmployee(User.GetEmployeeById(Id), DbUsage.GetWorkplaceByName(WorkplaceItem), DbUsage.GetSpecialitByName(SpecialitiesItem), SurName, Name, Patronymic);
            DbUsage dbUsage = new DbUsage();
            dbUsage.ViewRefreshMethod();
            OnPropertyChanged();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}

