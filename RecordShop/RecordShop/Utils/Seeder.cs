using RecordShop.Classes;

namespace RecordShop.Utils
{
    public class Seeder
    {
        public static void AddAlbumData(WebApplication app)
        {
            var scope = app.Services.CreateScope();
            var db = scope.ServiceProvider.GetService<RecordShopDbContext>();


            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            db.Artists.AddRange(
                new Artist() { Name = "Neutral Milk Hotel" },
                new Artist() { Name = "Radiohead" },
                new Artist() { Name = "The Strokes" }
                );

            db.SaveChanges();

            db.Albums.AddRange(

                new Album()
                {
                    Name = "In the Aeroplane Over the Sea",
                    ArtistID = 1,
                    ReleaseDate = 1998,
                    TotalMinutes = 39.45,
                },

                new Album()
                {
                    Name = "OK Computer",
                    ArtistID = 2,
                    ReleaseDate = 1997,
                    TotalMinutes = 53.25,
                },

                new Album
                {
                    Name = "Is This It",
                    ArtistID = 3,
                    ReleaseDate = 2001,
                    TotalMinutes = 36.28,
                }

                );

            db.SaveChanges();
        }
    }
}
