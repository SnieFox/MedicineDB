using System.Collections.Generic;

namespace MedicineDB.Entity.Tables
{
    internal class Location
    {
        public int Id { get; set; }
        public int? CountryID { get; set; }
        public int? CityID { get; set; }

        public List<Employee> Employees { get; set; }

        public List<Workplace> Workplaces { get; set; }
        public Country Country { get; set; }
        public City City { get; set; }
    }
}
