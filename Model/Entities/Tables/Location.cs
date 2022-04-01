using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicineDB.Entity.Tables
{
    internal class Location
    {
        public int Id { get; set; }
        public int CountryID { get; set; }
        public int CityID { get; set; }

        public List<Employee> Employee { get; set; }

        public List<Workplace> Workplace { get; set; }
        public Country Country { get; set; }
        public City City { get; set; }
    }
}
