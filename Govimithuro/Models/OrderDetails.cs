using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Govimithuro.Models
{
    public class OrderDetails
    {
        [Key]
        public int OrderId { get; set; }
        public string Feedback { get; set; }
        public string Email { get; set; }
    }
}
