namespace RecordShop.Backend.DTOs
{
    public class CreateOrderDTO
    {
        public int? UserID { get; set; }
        public int TotalPence { get; set; }
        public DeliveryAddressDTO DeliveryAddress { get; set; }
        public CustomerOrderInfoDTO CustomerOrderInfo { get; set; }
        public List<AlbumOrderDTO> OrderItems { get; set; }
    }
}
