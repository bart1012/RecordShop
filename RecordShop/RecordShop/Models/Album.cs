namespace RecordShop.Classes
{
    public class Album
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int ArtistID { get; set; }
        public int ReleaseDate { get; set; }
        public double TotalMinutes { get; set; }
        public Artist Artist { get; set; }


    }
}