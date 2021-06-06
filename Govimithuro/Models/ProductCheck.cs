using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Govimithuro.Models
{
    public class ProductCheck
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Email { get; set; }

        public int ReorderLevel { get; set; }
        public float Quantity { get; set; }
        public string AvailableQuantity { get; set; }
        public string Addresse { get; set; }
        public string CategoryName { get; set; }
        public string ProductDescription { get; set; }
        public float UnitPrice { get; set; }
        public float UnitWeight { get; set; }
        public string ImageName { get; set; }


        [NotMapped]
        public IFormFile ImageFile { get; set; }

        [NotMapped]
        public string ImageSrc { get; set; }
    }
}
