using MedicineDB.Entity.Tables;
using MedicineDB.Model.Entities;
using System;
using System.Linq;
using System.Windows;

namespace MedicineDB.Model
{
    internal class User
    {
        //Создать сотрудника
        public static string CreateEmployee(Workplace workplace, Speciality speciality, string surname, string name, string patronymic)
        {
            string result = "Готово!";
            using (MedicineDbContext db = new MedicineDbContext())
            {
                Employee employee = new Employee
                {
                    Surname = surname,
                    Name = name,
                    Patronymic = patronymic,
                    SpecialityID = speciality?.Id,
                    WorkplaceID = workplace?.Id
                };
                db.Employees.Add(employee);
                db.SaveChanges();
            }
            return result;
        }

        //Редактровать сотрудника
        public static string EditEmployee(Employee oldEmployee, Workplace newWorkplace, Speciality newSpeciality, string newSurname, string newName, string newPatronymic)
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

                    db.SaveChanges();
                    result = $"Сотрудник (Id - {employee.Id}) изменен";
                }
            }
            return result;
        }

        //Удалить сотрудника
        public static string DeleteEmployeeMethod(Employee employee)
        {
            string result = "";
            using (MedicineDbContext db = new MedicineDbContext())
            {
                try
                {
                    db.Employees.Remove(employee);
                    db.SaveChanges();
                    result = $"Сотрудник (Id - {employee.Id}) удален из базы";
                }
                catch (ArgumentNullException)
                {
                    MessageBox.Show("Нет такого Id!");
                }
            }
            return result;
        }

        //Получение места работы по Id
        public static Employee GetEmployeeById(int id)
        {
            using (MedicineDbContext db = new MedicineDbContext())
            {
                Employee employee = db.Employees.FirstOrDefault(p => p.Id == id);
                return employee;
            }
        }
    }
}
