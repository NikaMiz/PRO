using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ХранительПРО.Domain;

namespace ХранительПРО.Aplication.DTO
{
    public class GroupDTO
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
        public string DivisionEmployee { get; set; } = null!;

        [Required]
        public IEnumerable<UserDTO> Users { get; set; } = null!;
       
    }
}
