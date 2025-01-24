namespace RecordShopFrontEnd.Models
{
    public class AlbumFE
    {


        public int ID { get; set; }
        public string Name { get; set; }
        public string Artist { get; set; }
        public DateTime ReleaseDate { get; set; }
        public double TotalMinutes { get; set; }
        public List<string> Genres { get; set; }
        public string ImgURL { get; set; }

    }
}
