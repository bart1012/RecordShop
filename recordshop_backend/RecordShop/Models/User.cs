using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RecordShop.Backend.Models
{

    [Index(nameof(Email), IsUnique = true)]
    public class User
    {
        [JsonIgnore]
        public int Id { get; set; }

        [Required(ErrorMessage = "Email cannot be blank.")]
        [EmailAddress]
        public string Email { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Required(ErrorMessage = "Password cannot be blank.")]
        [StringLength(25, MinimumLength = 6)]
        public string Password { get; set; }
    }
}
