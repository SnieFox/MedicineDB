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

namespace MedicineDB.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        public MainWindowViewModel()
        {

            #region Commands
            OpenEditEmployeeWindow = new RelayCommand(OnOpenEditEmployeeWindowExecute, CanOpenEditEmployeeWindowExecute);
            OpenAddEmployeeWindow = new RelayCommand(OnOpenAddEmployeeWindowExecute, CanOpenAddEmployeeWindowExecute);
            #endregion

        }
        #region Methods
        //Получение полного списка сотрудников
        public static List<Employee> GetAllEmployees()
        {
            using(MedicineDbContext db = new MedicineDbContext())
            {
                var employees =  db.Employees.ToList();   
                return employees;
            }
        }

        //Получение места работы по Id
        public static Workplace GetWorkplaceById(int id)
        {
            using (MedicineDbContext db = new MedicineDbContext())
            {
                Workplace workplace = db.Workplaces.FirstOrDefault(p => p.Id == id);
                return workplace;
            }
        }
        //Получение специальности по Id
        public static Speciality GetSpecialitById(int id)
        {
            using (MedicineDbContext db = new MedicineDbContext())
            {
                Speciality specialit = db.Specialities.FirstOrDefault(p => p.Id == id);
                return specialit;
            }
        }

        //Создать сотрудника
        public static string CreateEmployee(Workplace workplace, Speciality speciality,  string surname, int age, string name, string patronymic)
        {
            string result = "Готово!";
            using(MedicineDbContext db = new MedicineDbContext())
            {
                Employee employee = new Employee
                {
                    Surname = surname,
                    Name = name,
                    Patronymic = patronymic,
                    Age = age,
                    SpecialityID = speciality.Id,
                    WorkplaceID = workplace.Id
                };
                db.Employees.Add(employee);
                db.SaveChanges();
            }
            return result;
        }

        //Удалить сотрудника
        public static string DeleteEmployee(Employee employee)
        {
            string result = "";
            using (MedicineDbContext db = new MedicineDbContext())
            {
                db.Employees.Remove(employee);
                db.SaveChanges();
                result = $"Сотрудник (Id - {employee.Id}) удален из базы";
            }
            return result;
        }

        //Редактровать сотрудника
        public static string EditEmployee(Employee oldEmployee, string newSurname, int newAge, string newName, string newPatronymic, Workplace newWorkplace, Speciality newSpeciality)
        {
            string result = "";
            using (MedicineDbContext db = new MedicineDbContext())
            {
                Employee employee = db.Employees.FirstOrDefault(e => e.Id == oldEmployee.Id);
                if (employee != null)
                {
                    employee.Name = newName;
                    employee.Surname = newSurname;
                    employee.Patronymic = newPatronymic;
                    employee.Workplace = newWorkplace;
                    employee.Speciality = newSpeciality;
                    employee.Age = newAge;

                    db.SaveChanges();
                    result = $"Сотрудник (Id - {employee.Id}) изменен";
                }
            }
            return result;
        }

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
        private List<Employee> allEmployees = GetAllEmployees();
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
        private string _IdTextBox = "Id";
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

        private string _SurnameTextBox = "Фамилия";
        public string SurnameTextBox
        {
            get => _SurnameTextBox;
            set
            {
                _SurnameTextBox= value;
                OnPropertyChanged();
            }
        }

        private string _NameTextBox = "Имя";
        public string NameTextBox
        {
            get => _NameTextBox;
            set
            {
                _NameTextBox= value;
                OnPropertyChanged();
            }
        }

        private string _PatronymicTextBox = "Отчество";
        public string PatronymicTextBox
        {
            get => _PatronymicTextBox;
            set
            {
                _PatronymicTextBox= value;
                OnPropertyChanged();
            }
        }

        private string _SpecialityTextBox = "Специальность";
        public string SpecialityTextBox
        {
            get => _SpecialityTextBox;
            set
            {
                _SpecialityTextBox = value;
                OnPropertyChanged();
            }
        }
        private string _WorkplaceTextBox = "Место работы";
        public string WorkplaceTextBox
        {
            get => _WorkplaceTextBox;
            set
            {
                _WorkplaceTextBox= value;
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
