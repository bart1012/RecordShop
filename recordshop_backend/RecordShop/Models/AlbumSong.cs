using System.ComponentModel.DataAnnotations;

namespace RecordShop.Models
{
    public class AlbumSong
    {
        [Key]
        public int Id { get; set; }

        public int AlbumID { get; set; }
        public Album Album { get; set; }

        public int SongID { get; set; }
        public Song Song { get; set; }
    }
}