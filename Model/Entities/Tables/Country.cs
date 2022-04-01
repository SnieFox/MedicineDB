using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicineDB.Entity.Tables
{
    internal class Country
    {
        public int Id { get; set; }
        public string CountyName { get; set; }

        public List<Location> Location { get; set; }
    }
}