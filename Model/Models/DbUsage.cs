using MedicineDB.Entity.Tables;
using MedicineDB.Model.Entities;
using MedicineDB.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicineDB.Model.Models
{
    internal class DbUsage
    {
        //метод обновления окна 
        public void ViewRefreshMethod()
        {
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            mainWindowViewModel.AllEmployees = GetAllEmployees();
            MainWindow.AllEmployeesView.ItemsSource = null;
            MainWindow.AllEmployeesView.Items.Clear();
            MainWindow.AllEmployeesView.ItemsSource = GetAllEmployees();
            MainWindow.AllEmployeesView.Items.Refresh();
        }
        //Получение полного списка сотрудников
        public static List<Employee> GetAllEmployees()
        {
            using (MedicineDbContext db = new MedicineDbContext())
            {
                var employees = db.Employees.ToList();
                return employees;
            }
        }
        //Получение полного списка специальностей
        public static List<string> GetSpecialities()
        {
            using (MedicineDbContext db = new MedicineDbContext())
            {
                var specialities = db.Specialities.ToList();
                List<string> result = new List<string>();
                foreach (var employee in specialities)
                {
                    result.Add(employee.Specialty);
                }
                return result;
            }
        }

        //Получение полного списка мест работы
        public static List<string> GetWorkplace()
        {
            using (MedicineDbContext db = new MedicineDbContext())
            {
                var workplaces = db.Workplaces.ToList();
                List<string> result = new List<string>();
                foreach (var workplace in workplaces)
                {
                    result.Add(workplace.Name);
                }
                return result;
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

        //Получение Места работы по названию
        public static Workplace GetWorkplaceByName(string name)
        {
            using (MedicineDbContext db = new MedicineDbContext())
            {
                Workplace workplace = db.Workplaces.FirstOrDefault(p => p.Name == name);
                return workplace;
            }
        }
        //Получение специальности по названию
        public static Speciality GetSpecialitByName(string name)
        {
            using (MedicineDbContext db = new MedicineDbContext())
            {
                Speciality specialit = db.Specialities.FirstOrDefault(p => p.Specialty == name);
                return specialit;
            }
        }

    }
}
