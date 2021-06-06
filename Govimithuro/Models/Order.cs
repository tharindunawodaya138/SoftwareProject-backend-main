using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Govimithuro.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
      
        public string ProductName { get; set; }
        public float Quantity { get; set; }
        public float UnitPrice { get; set; }

        public string Email { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerName { get; set; }
        public string Date { get; set; }

    }
}
