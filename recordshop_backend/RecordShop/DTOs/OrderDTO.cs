using RecordShop.Backend.Utils;
using System.Text.Json.Serialization;

namespace RecordShop.Backend.DTOs
{
    public class OrderDTO
    {
        public int? UserID { get; set; }
        public int TotalPence { get; set; }

        [JsonIgnore]
        public OperationResult Status { get; set; }

        [JsonIgnore]
        public DateTime CreatedAt { get; set; }
        public DeliveryAddressDTO DeliveryAddress { get; set; }
        public CustomerOrderInfoDTO CustomerOrderInfo { get; set; }
        public List<AlbumOrderDTO> OrderItems { get; set; }
    }
}
