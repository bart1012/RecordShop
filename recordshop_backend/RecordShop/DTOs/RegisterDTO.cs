namespace RecordShop.Backend.DTOs
{
    public class RegisterDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }
        public string AddressLine { get; set; }
        public string Town { get; set; }
        public string Postcode { get; set; }
        public string Country { get; set; }
    }
}
