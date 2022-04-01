using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicineDB.Entity.Tables
{
    internal class Workplace
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LocationID { get; set; }

        public Location Location { get; set; }
        public List<Employee> Employee { get; set; }
    }
}
