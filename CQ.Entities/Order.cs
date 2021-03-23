using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CQ.Entities
{
    public class Order:Entity
    {
        [Required]
        public string UserEmail { get; set; }
        public ICollection<OrderItem> Items { get; set; }
    }
}
