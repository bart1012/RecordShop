namespace RecordShop.Models
{
    public class Genre
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<AlbumGenre> AlbumGenres { get; set; } = new();

    }
}