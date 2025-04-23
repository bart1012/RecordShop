namespace RecordShop.Models
{
    public class Artist
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ImgURL { get; set; }
        public List<AlbumArtists> AlbumArtists { get; set; } = new();
    }
}