using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ХранительПРО.Domain
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string SurName { get; set; } = null!;
        public string? MiddleName { get; set; }
        public string? Division { get; set; }
        public string? Department { get; set; }
        public string? CodeEmployee { get; set; }

    }
}
