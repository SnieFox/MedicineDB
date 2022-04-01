using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicineDB.Entity.Tables
{
    internal class City
    {
        public int Id { get; set; }
        public string CityName { get; set; }

        public List<Location> Location { get; set; }
    }
}