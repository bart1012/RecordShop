using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecordShop.Backend.Models
{
    public class OrderDetails
    {
        public int ID { get; set; }
        [Required]

        [ForeignKey("Order")]
        public int OrderID { get; set; }
        public Order Order { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string AddressLine { get; set; }
        [Required]
        public string Postcode { get; set; }
        [Required]
        public string Town { get; set; }
        [Required]
        public string Country { get; set; }
    }
}
