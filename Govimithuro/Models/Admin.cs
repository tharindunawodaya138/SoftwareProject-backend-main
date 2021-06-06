using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Govimithuro.Models
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        public string AdminFName { get; set; }
        public string AdminLName { get; set; }
        public string Password { get; set; }
    }
}
//check