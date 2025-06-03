using System.ComponentModel.DataAnnotations;

namespace RecordShop.Backend.Models
{
    public class OrderItem
    {
        public int ID { get; set; }
        [Required] public int OrderID { get; set; }
        public Order Order { get; set; }
        [Required] public int AlbumID { get; set; }
        [Required] public int Quantity { get; set; }
        [Required] public int PricePence { get; set; }
        [Required] public string AlbumName { get; set; }
        [Required] public string AlbumArtist { get; set; }
    }
}
