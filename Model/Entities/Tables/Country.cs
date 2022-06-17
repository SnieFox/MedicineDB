using System.Collections.Generic;

namespace MedicineDB.Entity.Tables
{
    internal class Country
    {
        public int Id { get; set; }
        public string CountyName { get; set; }

        public List<Location> Locations { get; set; }
    }
}