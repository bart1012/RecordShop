using System.Text.Json.Serialization;

namespace RecordShop.Models
{
    public class Song
    {
        [JsonIgnore]
        public int ID { get; set; }
        public string Name { get; set; }
        public double Duration { get; set; }

    }
}