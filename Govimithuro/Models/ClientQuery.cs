using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Govimithuro.Models
{
    public class ClientQuery
    {
        [Key]
        public int QueryId { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
