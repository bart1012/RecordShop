namespace RecordShop.Classes
{
    public class Song
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Duration { get; set; }
        public int AlbumID { get; set; }
        public Album Album { get; set; }
    }
}