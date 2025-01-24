using System.ComponentModel.DataAnnotations;

namespace RecordShop.Models
{
    public class AlbumGenre
    {
        [Key]
        public int Id { get; set; }

        public int AlbumID { get; set; }
        public Album Album { get; set; }


        public int GenreID { get; set; }
        public Genre Genre { get; set; }
    }
}