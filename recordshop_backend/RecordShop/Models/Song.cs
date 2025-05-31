using System.Text.Json.Serialization;

namespace RecordShop.Models
{
    public class Song
    {
        [JsonIgnore]
        public int ID { get; set; }
        public required string Name { get; set; }
        public required double Duration { get; set; }

    }
}