using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ХранительПРО.Aplication.DTO
{
    public class RegistrationDTO
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[^\\da-zA-Z]).{8,15}$")]
        [Required]        
        public string Password { get; set; }

    }
}
