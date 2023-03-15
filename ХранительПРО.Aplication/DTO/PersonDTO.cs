using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ХранительПРО.Domain;

namespace ХранительПРО.Aplication.DTO
{
    public class PersonDTO
    {
        [Required]
        public AuthorizationDTO User { get; set; } = null!;
        [Required]
        public string NameEmployee { get; set; } = null!;
        [Required]
        public string SurNameEmployee { get; set; } = null!;
        [Required]
        public string? MiddleNameEmployee { get; set; }
        [Required]
        public string DivisionEmployee { get; set; }
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
