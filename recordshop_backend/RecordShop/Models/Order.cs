using RecordShop.Backend.Utils;
using System.ComponentModel.DataAnnotations;

namespace RecordShop.Backend.Models
{
    public class Order
    {
        [Key]
        public int ID { get; set; }
        public int? UserID { get; set; }

        [Required]
        public int TotalPence { get; set; }

        [Required]
        public OrderStatus Status { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public OrderDetails? OrderDetails { get; set; }

        public List<OrderItem?> OrderItems { get; set; }
    }
}
