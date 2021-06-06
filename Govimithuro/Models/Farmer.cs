using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Govimithuro.Models
{
    public class Farmer
    {
        [Key]
        public int FarmerID { get; set; }
        public string FarmerFName { get; set; }
        public string FarmerLName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string ASCRNo { get; set; }
        public string AgriBranch { get; set; }
        public string NIC { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
    }
}
