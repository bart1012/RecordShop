using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace RecordShop.Backend.Models
{
    public class User : IdentityUser
    {
        [PersonalData]
        [Required]
        public string FirstName { get; set; }

        [PersonalData]
        [Required]
        public string LastName { get; set; }

        [PersonalData]
        [Required]
        public string AddressLine { get; set; }

        [PersonalData]
        [Required]
        public string Postcode { get; set; }

        [PersonalData]
        [Required]
        public string Town { get; set; }

        [PersonalData]
        [Required]
        public string Country { get; set; }



    }
}
