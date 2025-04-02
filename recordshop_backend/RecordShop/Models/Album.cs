namespace RecordShop.Models
{
    public class Album
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseYear { get; set; }
        public double TotalMinutes { get; set; }
        public int PricePence { get; set; }
        public string ImgURL { get; set; }


        public List<AlbumArtists> AlbumArtists { get; set; } = new();
        public List<AlbumSong> AlbumSongs { get; set; } = new();
        public List<AlbumGenre> AlbumGenres { get; set; } = new();
    }
}