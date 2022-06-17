using System.Collections.Generic;

namespace MedicineDB.Entity.Tables
{
    internal class Speciality
    {
        public int Id { get; set; }
        public string Specialty { get; set; }

        public List<Employee> Employees { get; set; }
    }
}
