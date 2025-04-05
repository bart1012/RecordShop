using System.Text.Json.Serialization;

namespace RecordShop.Models
{
    public class AlbumDTO
    {
        [JsonIgnore]
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseYear { get; set; }
        public double TotalMinutes { get; set; }
        public int PricePence { get; set; }
        public string ImgURL { get; set; }
        public List<string> Artists { get; set; }
        public List<string> Genres { get; set; }
        public List<Song> Songs { get; set; }


    }
}
