using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ХранительПРО.Domain
{
    public class GroupVisiting
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string SurName { get; set; } = null!;
        public string? MiddleName { get; set; }
        public string Email { get; set; } = null!;
        public DateTime BirthDay { get; set; }
        public string Seria { get; set; } = null!;
        public string Number { get; set; } = null!;
        public User User { get; set; } = null!;
        public InfoGroup Group { get; set; } = null!;       
    }
}
