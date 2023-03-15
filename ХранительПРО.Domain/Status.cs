using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ХранительПРО.Domain
{
    public class Status
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!; 
        public string? Message { get; set; }
    }
}
