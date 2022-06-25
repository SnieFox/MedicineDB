using MedicineDB.Entity.Tables;
using MedicineDB.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicineDB.Model.Models
{
    internal class SearchEmployee
    {
        public static List<Employee> SearchEmployeeByParams(int id, string surname, string name, string patronymic, Workplace workplace, Speciality speciality)
        {
            using (MedicineDbContext db = new MedicineDbContext())
            {
                string sql = $"SELECT * FROM Employee WHERE Id LIKE '%{id}%' AND Name LIKE '%{name}%' AND Surname LIKE '%{surname}%' AND Patronymic LIKE '%{patronymic}%' AND SpecialityID LIKE '{speciality.Id}' AND WorkplaceID LIKE '{workplace.Id}'";
                var employees = db.Employees.FromSqlRaw(sql).ToList();
                ////List<Employee> employees = db.Employees.Where(emp => emp.Id == id).ToList();
                return employees;
            }
        }
    }
}
