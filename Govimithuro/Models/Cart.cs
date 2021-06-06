using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Govimithuro.Models
{
    public class Cart
    {
        [Key]
        public int ProductID { get; set; }
        public int CustomerID { get; set; }
        public string ProductName { get; set; }
        public int NumOfProducts { get; set; }
        public int TotalPrice { get; set; }
    }
}
