using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Govimithuro.Models
{
    public class UserRegistrationModel
    {
        // common attributes
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Password and confirm password does not match")]
        public string ConfirmPassword { get; set; }

        public string Address { get; set; }
        public string Phone { get;set; }

        // For farmer
        public string AscrNo { get; set; }
        public string AgriBranch { get; set; }
        public string Nic { get; set; }
        
        // for customer
        


    }
}
