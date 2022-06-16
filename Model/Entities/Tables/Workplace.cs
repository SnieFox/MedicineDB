using System.Collections.Generic;

namespace MedicineDB.Entity.Tables
{
    internal class Workplace
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? LocationID { get; set; }
        public Location Location { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
