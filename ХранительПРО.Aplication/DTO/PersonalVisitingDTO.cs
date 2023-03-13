using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ХранительПРО.Domain;

namespace ХранительПРО.Aplication.DTO
{
    public class PersonalVisitingDTO
    {
        public string Division { get; set; } = null!;
        public DateTime Date { get; set; }
        public Status Status { get; set; } = null!;
    }
}
