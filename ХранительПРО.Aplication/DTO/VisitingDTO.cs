using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ХранительПРО.Domain;

namespace ХранительПРО.Aplication.DTO
{
    public class VisitingDTO
    {
        public string Division { get; set; }
        public DateTime CreateDate { get; set; }
        public int StatusId { get; set; }
        public string Login { get; set; }
    }
}
