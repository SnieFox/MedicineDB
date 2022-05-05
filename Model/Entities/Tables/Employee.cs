using MedicineDB.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicineDB.Entity.Tables
{
    internal class Employee
    {

        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public int Age { get; set; }
        public int LocationID { get; set; }
        public int SpecialityID { get; set; }
        public int WorkplaceID { get; set; }

        public Speciality Speciality { get; set; }
        public Location Location { get; set; }
        public Workplace Workplace { get; set; }


        [NotMapped]
        public Workplace EmployeeWorkplace
        {
            get
            {
                return MainWindowViewModel.GetWorkplaceById(WorkplaceID);
            }
        }
        public Speciality EmployeeSpesiality
        {
            get
            {
                return MainWindowViewModel.GetSpecialitById(SpecialityID);
            }
        }
    }
}
