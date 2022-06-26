using System.Collections.Generic;

namespace MedicineDB.Entity.Tables
{
    internal class City
    {
        public int Id { get; set; }
        public string CityName { get; set; }

        public List<Location> Locations { get; set; }
    }
}