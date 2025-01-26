namespace RecordShop.Models
{
    public class AlbumDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public double TotalMinutes { get; set; }
        public List<string> Artists { get; set; }
        public List<string> Genres { get; set; }
        public List<Song> Songs { get; set; }
    }
}
