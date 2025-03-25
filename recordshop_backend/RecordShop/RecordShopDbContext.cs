using Microsoft.EntityFrameworkCore;
using RecordShop.Models;



namespace RecordShop
{
    public class RecordShopDbContext(DbContextOptions<RecordShopDbContext> options) : DbContext(options)
    {
        public DbSet<Album> Albums { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<AlbumArtists> AlbumArtists { get; set; }
        public DbSet<AlbumGenre> AlbumGenres { get; set; }
        public DbSet<AlbumSong> AlbumSongs { get; set; }


    }
}

//namespace RecordShop
//{
//    public class RecordShopDbContext : DbContext
//    {
//        public DbSet<Album> Albums { get; set; }
//        public DbSet<Song> Songs { get; set; }
//        public DbSet<Artist> Artists { get; set; }
//        public DbSet<Genre> Genres { get; set; }
//        public DbSet<AlbumArtists> AlbumArtists { get; set; }
//        public DbSet<AlbumGenre> AlbumGenres { get; set; }
//        public DbSet<AlbumSong> AlbumSongs { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            optionsBuilder.UseSqlServer("Server=DESKTOP-QA5JG2D\\SQLEXPRESS01;Database=RecordShopDB;User Id=bart1012;Password=Krakers51!;TrustServerCertificate = True");
//        }
//    }
//}

