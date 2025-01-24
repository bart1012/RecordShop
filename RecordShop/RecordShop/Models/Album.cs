using System.Text.Json.Serialization;

namespace RecordShop.Models
{
    public class Album
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int ArtistID { get; set; }
        [JsonIgnore]
        public Artist Artist { get; set; }
        public DateTime ReleaseDate { get; set; }
        public double TotalMinutes { get; set; }

    }
}