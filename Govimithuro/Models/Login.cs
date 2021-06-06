using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Govimithuro.Models
{
    public class Login
    {
        [Key]
        public int LoginId { get; set; }
        
        public string Role { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

       [Required(ErrorMessage = "Cannot leave this field empty")]
        public string Password { get; set; }
    }
}
