using MedicineDB.Model.Models;

namespace MedicineDB.Entity.Tables
{
    internal class Employee
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public int? SpecialityID { get; set; }
        public int? WorkplaceID { get; set; }

        public Speciality Speciality { get; set; }
        public Workplace Workplace { get; set; }

        public Workplace EmployeeWorkplace
        {
            get
            {
                return DbUsage.GetWorkplaceById(WorkplaceID.Value);
            }
        }
        public Speciality EmployeeSpesiality
        {
            get
            {
                return DbUsage.GetSpecialitById(SpecialityID.Value);
            }
        }
    }
}
