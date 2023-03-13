using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ХранительПРО.Domain
{
    public class InfoGroup
    {
        public int Id { get; set; }
        public Employee Employee { get; set; } = null!;
        public DateTime Created { get; set; }
    }
}
