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
        [StringLength(30, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; }

        [Required]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Please enter valid phone no.")]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        [StringLength(254, ErrorMessage = "Email is too long")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Address line is too long")]
        public string AddressLine { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "Postcode is too long")]
        public string Postcode { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Town is too long")]
        public string Town { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Country is too long")]
        public string Country { get; set; }
    }
}
