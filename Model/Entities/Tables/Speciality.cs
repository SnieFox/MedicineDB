using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicineDB.Entity.Tables
{
    internal class Speciality
    {
        public int Id { get; set; }
        public string Specialty { get; set; }

        public List<Employee> Employee { get; set; }
    }
}
