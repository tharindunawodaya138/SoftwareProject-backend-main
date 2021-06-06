using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Govimithuro.Models
{
    public class DeliveryInfo
    {
        [Key]
        public int DeliveryId { get; set; }
        
        public int OrderId { get; set; }
        public string BoughtDate { get; set; }
        public string ProductName { get; set; }
        public float Quantity { get; set; }
        public string FarmerName { get; set; }
        public string FarmerEmail { get; set; }
        public string FarmerPhone { get; set; }
        public string FarmerAddress { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerAddress { get; set; }
        public string Accepted { get; set;  }
        public string Transit { get; set; }
        public string Delivered { get; set; }
        public string ExpectedDelivery { get; set; }
        public string NotReceived { get; set; }
        public string DisputeMessage { get; set; }
    }
}
