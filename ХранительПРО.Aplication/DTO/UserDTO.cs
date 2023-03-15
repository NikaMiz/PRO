using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ХранительПРО.Aplication.DTO
{
    public class UserDTO
    {      
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string SurName { get; set; } = null!;
        [Required]
        public string? MiddleName { get; set; }
        [Required]
        [Phone]
        public string Telephone { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        public DateTime BirthDay { get; set; }
        [Required]
        public string Seria { get; set; } = null!;
        [Required]
        public string Number { get; set; } = null!;
    }
}
