using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Govimithuro.Models
{
    public class Review
    {
        [Key]
        public int ReviewID { get; set; }
        public string FarmerEmail { get; set; }
        public string CustomerName { get; set; }
        public string Reviews { get; set; }
        public string Product { get; set; }
        public string Rank { get; set; }
        public string Date { get; set; }
    }
}
