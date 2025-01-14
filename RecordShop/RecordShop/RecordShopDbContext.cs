using Microsoft.EntityFrameworkCore;
using RecordShop.Classes;
namespace RecordShop
{
    public class RecordShopDbContext(DbContextOptions<RecordShopDbContext> options) : DbContext(options)
    {
        public DbSet<Album> Albums { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<AlbumArtist> AlbumArtists { get; set; }
        public DbSet<AlbumGenre> AlbumGenres { get; set; }

    }
}
