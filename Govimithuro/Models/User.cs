using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Govimithuro.Models
{
    public class User : IdentityUser
    {
        // common attributes
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Address { get; set; }
        public string Phone { get; set; }

        // For farmer only
        public string AscrNo { get; set; }
        public string AgriBranch { get; set; }
        public string Nic { get; set; }
    }
}
