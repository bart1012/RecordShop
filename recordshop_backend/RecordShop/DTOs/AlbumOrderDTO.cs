namespace RecordShop.Backend.DTOs
{
    public class AlbumOrderDTO
    {
        public int AlbumID { get; set; }
        public string AlbumName { get; set; }
        public string AlbumArtist { get; set; }
        public int Quantity { get; set; }
        public int TotalPriceInPence { get; set; }
    }
}
