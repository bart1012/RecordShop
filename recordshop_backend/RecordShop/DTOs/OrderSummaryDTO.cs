using RecordShop.Backend.Utils;

namespace RecordShop.Backend.DTOs
{
    public class OrderSummaryDTO
    {
        public int ID { get; set; }
        public string? UserID { get; set; }
        public int TotalPence { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }

        public DeliveryAddressDTO DeliveryAddress { get; set; }
        public CustomerOrderInfoDTO CustomerOrderInfo { get; set; }
        public List<AlbumOrderDTO> OrderItems { get; set; }
    }
}
