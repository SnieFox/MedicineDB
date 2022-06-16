using MedicineDB.Commands;
using MedicineDB.ViewModels.Base;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using MedicineDB.Model.Entities;
using System.Diagnostics;
using System;
using MedicineDB.Entity.Tables;
using System.Collections.Generic;
using System.Linq;
using MedicineDB.Model;
using System.Windows;
using MedicineDB.View;
using MedicineDB.Model.Models;

namespace MedicineDB.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        public MainWindowViewModel()
        {

            #region Commands
            OpenEditEmployeeWindow = new RelayCommand(OnOpenEditEmployeeWindowExecute, CanOpenEditEmployeeWindowExecute);
            OpenAddEmployeeWindow = new RelayCommand(OnOpenAddEmployeeWindowExecute, CanOpenAddEmployeeWindowExecute);
            OpenDeleteEmployeeWindow = new RelayCommand(OnOpenDeleteEmployeeWindowExecute, CanOpenDeleteEmployeeWindowExecute);
            #endregion

        }
        #region Methods

        //Методы открытия окон 
        private void SetCenterPositionAndOpen(Window window)
        {
            window.Owner = Application.Current.MainWindow; 
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.Show();

        }
        private void OpenAddEmployeeWindowMethod()
        {
            AddEmployeeWindow addEmployeeWindow = new AddEmployeeWindow();
            SetCenterPositionAndOpen(addEmployeeWindow);

        }
        private void OpenEditEmployeeWindowMethod()
        {
            EditEmployeeWindow editEmployeeWindow = new EditEmployeeWindow();
            SetCenterPositionAndOpen(editEmployeeWindow);
        }
        private void OpenDeleteEmployeeWindowMethod()
        {
            DeleteEmployeeWindow deleteEmployeeWindow = new DeleteEmployeeWindow();
            SetCenterPositionAndOpen(deleteEmployeeWindow);

        }

        #endregion

        #region Fields

        //Поле заголовка окна MainWindow
        private string _Title = "MedicineDb";
        public string Title
        {
            get => _Title;
            set
            {
                _Title = value;
                OnPropertyChanged();
            }
        }

        //Отображение полного списка сотрудников
        private List<Employee> allEmployees = DbUsage.GetAllEmployees();
        public List<Employee> AllEmployees
        {
            get => allEmployees;
            set
            {
                allEmployees = value;
                OnPropertyChanged();
            }
        }

        // Поля, которые принимают введенные данные в форму для поиска сотрудников
        private string _IdTextBox = "";
        public string IdTextBox
        {
            get => _IdTextBox;
            set
            {
                if (value != null)
                {
                    _IdTextBox = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _SurnameTextBox = "";
        public string SurnameTextBox
        {
            get => _SurnameTextBox;
            set
            {
                _SurnameTextBox= value;
                OnPropertyChanged();
            }
        }

        private string _NameTextBox = "";
        public string NameTextBox
        {
            get => _NameTextBox;
            set
            {
                _NameTextBox= value;
                OnPropertyChanged();
            }
        }

        private string _PatronymicTextBox = "";
        public string PatronymicTextBox
        {
            get => _PatronymicTextBox;
            set
            {
                _PatronymicTextBox= value;
                OnPropertyChanged();
            }
        }

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
        #endregion 

        #region Commands
        //Комманды для кнопок представления

        //Команда кнопки поиска по критериям

        //Команда кнопки очистки результатов

        //Команда кнопки добаввления сотрудников
        public RelayCommand OpenAddEmployeeWindow { get; }
        private bool CanOpenAddEmployeeWindowExecute(object arg) => true;
        private void OnOpenAddEmployeeWindowExecute(object obj)
        {
            OpenAddEmployeeWindowMethod();
        }

        //Команда кнопки удаления сотрудников
        public RelayCommand OpenDeleteEmployeeWindow { get; }
        private bool CanOpenDeleteEmployeeWindowExecute(object arg) => true;
        private void OnOpenDeleteEmployeeWindowExecute(object obj)
        {
            OpenDeleteEmployeeWindowMethod();
        }
        //Команда кнопки изменения данных сотрудников
        public RelayCommand OpenEditEmployeeWindow { get; }
        private bool CanOpenEditEmployeeWindowExecute(object arg) => true;
        private  void OnOpenEditEmployeeWindowExecute(object obj)
        {
            OpenEditEmployeeWindowMethod();
        }

        //Комманды для очистки текста в поиске


        #endregion


        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
