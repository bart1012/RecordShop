namespace RecordShop.Backend.DTOs
{
    public class DeliveryAddressDTO
    {
        public string AddressLine { get; set; }
        public string Postcode { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string Country { get; set; }
    }
}
