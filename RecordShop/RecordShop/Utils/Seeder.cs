using RecordShop.Models;

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

                   ReleaseYear = 1998,
                   TotalMinutes = 39.45,
               },

            new Album()
            {
                Name = "OK Computer",
                ReleaseYear = 1997

            }


                );

            db.SaveChanges();
        }
    }
}
