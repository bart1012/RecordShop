global using JsonPatchDocument = Microsoft.AspNetCore.JsonPatch.JsonPatchDocument;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using RecordShop.Backend.DbContexts;
using RecordShop.Models;
using RecordShop.Repositories;

namespace RecordShop.Tests
{
    public class RepositoryTests
    {


        [Test]
        public void GetAllAlbums_ReturnsAlbumListFromDbContext()
        {

            //Arrange
            DbContextOptionsBuilder<RecordShopDbContext> dbOptionsBuilder = new DbContextOptionsBuilder<RecordShopDbContext>().UseInMemoryDatabase("InMemoryDb");
            RecordShopDbContext db = new RecordShopDbContext(dbOptionsBuilder.Options);
            db.Database.EnsureDeleted();
            db.Albums.AddRange(

                new Album()
                {
                    Name = "In the Aeroplane Over the Sea",
                    ReleaseYear = new DateTime(1998, 01, 13),
                    TotalMinutes = 39.45,
                    PricePence = 1200,
                    ImgURL = "AlbumCover1"
                },

                 new Album()
                 {
                     Name = "Ok Computer",
                     ReleaseYear = new DateTime(1997, 10, 18),
                     TotalMinutes = 32.00,
                     PricePence = 1500,
                     ImgURL = "AlbumCover2"
                 },

                   new Album()
                   {
                       Name = "Is This It",
                       ReleaseYear = new DateTime(2002, 10, 18),
                       TotalMinutes = 35.00,
                       PricePence = 1000,
                       ImgURL = "AlbumCover3"
                   }

                );
            db.SaveChanges();
            AlbumRepository albumRepository = new AlbumRepository(db);

            //Act
            var result = albumRepository.RetrieveAllAlbums();
            db.Database.EnsureDeleted();

            //Assert
            result.Should().BeEquivalentTo(new List<Album>()
            {
                  new Album()
                {
                    ID = 1,
                    Name = "In the Aeroplane Over the Sea",
                    ReleaseYear = new DateTime(1998,01,13),
                    TotalMinutes = 39.45,
                    PricePence = 1200,
                    ImgURL = "AlbumCover1"
                },

                 new Album()
                 {
                     ID = 2,
                     Name = "Ok Computer",
                     ReleaseYear = new DateTime(1997, 10, 18),
                     TotalMinutes = 32.00,
                     PricePence = 1500,
                     ImgURL = "AlbumCover2"
                 },

                   new Album()
                   {
                        ID = 3,
                       Name = "Is This It",
                       ReleaseYear = new DateTime(2002, 10, 18),
                       TotalMinutes = 35.00,
                       PricePence = 1000,
                       ImgURL = "AlbumCover3"
                   }
            });


        }

        [Test]
        public void GetAllAlbums_ReturnsEmptyListIfDbTableIsEmpty()
        {

            //Arrange
            DbContextOptionsBuilder<RecordShopDbContext> dbOptionsBuilder = new DbContextOptionsBuilder<RecordShopDbContext>().UseInMemoryDatabase("InMemoryDb");
            RecordShopDbContext db = new RecordShopDbContext(dbOptionsBuilder.Options);
            db.Database.EnsureDeleted();
            AlbumRepository albumRepository = new AlbumRepository(db);

            //Act
            var result = albumRepository.RetrieveAllAlbums();

            //Assert
            result.Should().BeNullOrEmpty();
        }

        [Test]
        public void GetAlbumByID_ReturnsAlbum()
        {

            //Arrange
            DbContextOptionsBuilder<RecordShopDbContext> dbOptionsBuilder = new DbContextOptionsBuilder<RecordShopDbContext>().UseInMemoryDatabase("InMemoryDb");
            RecordShopDbContext db = new RecordShopDbContext(dbOptionsBuilder.Options);
            db.Database.EnsureDeleted();
            db.Albums.Add(

                new Album()
                {
                    ID = 1,
                    Name = "Is This It",
                    ReleaseYear = new DateTime(2002, 10, 18),
                    TotalMinutes = 35.00,
                    PricePence = 1000,
                    ImgURL = "AlbumCover3"
                });

            db.SaveChanges();

            AlbumRepository albumRepository = new AlbumRepository(db);

            //Act
            var result = albumRepository.FindAlbumByID(1);

            //Assert
            result.Should().BeEquivalentTo(new Album()
            {
                ID = 1,
                Name = "Is This It",
                ReleaseYear = new DateTime(2002, 10, 18),
                TotalMinutes = 35.00,
                PricePence = 1000,
                ImgURL = "AlbumCover3"
            });


        }

        [Test]
        public void GetAlbumByID_ReturnsNullIfAlbumNotFound()
        {

            //Arrange
            DbContextOptionsBuilder<RecordShopDbContext> dbOptionsBuilder = new DbContextOptionsBuilder<RecordShopDbContext>().UseInMemoryDatabase("InMemoryDb");
            RecordShopDbContext db = new RecordShopDbContext(dbOptionsBuilder.Options);
            db.Database.EnsureDeleted();
            db.SaveChanges();

            AlbumRepository albumRepository = new AlbumRepository(db);

            //Act
            var result = albumRepository.FindAlbumByID(1);

            //Assert
            result.Should().BeNull();


        }

        [Test]
        public void DeleteAlbum_ReturnsTrueIfFoundAndDeletedFromDb()
        {

            //Arrange
            DbContextOptionsBuilder<RecordShopDbContext> dbOptionsBuilder = new DbContextOptionsBuilder<RecordShopDbContext>().UseInMemoryDatabase("InMemoryDb");
            RecordShopDbContext db = new RecordShopDbContext(dbOptionsBuilder.Options);
            db.Database.EnsureDeleted();
            db.Albums.Add(

               new Album()
               {
                   ID = 1,
                   Name = "Is This It",
                   ReleaseYear = new DateTime(2002, 10, 18),
                   TotalMinutes = 35.00,
                   PricePence = 1000,
                   ImgURL = "AlbumCover3"
               });

            db.SaveChanges();

            AlbumRepository albumRepository = new AlbumRepository(db);

            //Act
            var result = albumRepository.DeleteAlbum(1);

            //Assert
            db.Albums.Should().BeEmpty();
            result.Should().BeTrue();


        }

        [Test]
        public void DeleteAlbum_ReturnsFalseIfAlbumNotFoundInDb()
        {

            //Arrange
            DbContextOptionsBuilder<RecordShopDbContext> dbOptionsBuilder = new DbContextOptionsBuilder<RecordShopDbContext>().UseInMemoryDatabase("InMemoryDb");
            RecordShopDbContext db = new RecordShopDbContext(dbOptionsBuilder.Options);
            db.Database.EnsureDeleted();
            db.Albums.Add(

                new Album()
                {
                    ID = 1,
                    Name = "Is This It",
                    ReleaseYear = new DateTime(2002, 10, 18),
                    TotalMinutes = 35.00,
                    PricePence = 1000,
                    ImgURL = "AlbumCover3"
                });

            db.SaveChanges();

            AlbumRepository albumRepository = new AlbumRepository(db);

            //Act
            var result = albumRepository.DeleteAlbum(2);

            //Assert
            db.Albums.Should().NotBeEmpty();
            result.Should().BeFalse();


        }

        [Test]
        public void UpdateAlbumDetails_ReturnsUpdatedAlbum()
        {

            //Arrange
            DbContextOptionsBuilder<RecordShopDbContext> dbOptionsBuilder = new DbContextOptionsBuilder<RecordShopDbContext>().UseInMemoryDatabase("InMemoryDb");
            RecordShopDbContext db = new RecordShopDbContext(dbOptionsBuilder.Options);
            JsonPatchDocument jsonPatch = new JsonPatchDocument();
            jsonPatch.Replace("/TotalMinutes", 40);
            db.Database.EnsureDeleted();
            db.Albums.Add(

                new Album()
                {
                    ID = 1,
                    Name = "Is This It",
                    ReleaseYear = new DateTime(2002, 10, 18),
                    TotalMinutes = 35.00,
                    PricePence = 1000,
                    ImgURL = "AlbumCover3"
                });
            db.SaveChanges();

            AlbumRepository albumRepository = new AlbumRepository(db);

            //Act
            var result = albumRepository.UpdateAlbumDetails(1, jsonPatch);

            //Assert

            result.Should().BeEquivalentTo(new Album()
            {
                ID = 1,
                Name = "Is This It",
                ReleaseYear = new DateTime(2002, 10, 18),
                TotalMinutes = 40.00,
                PricePence = 1000,
                ImgURL = "AlbumCover3"
            });


        }

        [Test]
        public void UpdateAlbumDetails_AlbumNotFound()
        {

            //Arrange
            DbContextOptionsBuilder<RecordShopDbContext> dbOptionsBuilder = new DbContextOptionsBuilder<RecordShopDbContext>().UseInMemoryDatabase("InMemoryDb");
            RecordShopDbContext db = new RecordShopDbContext(dbOptionsBuilder.Options);
            JsonPatchDocument jsonPatch = new JsonPatchDocument();
            jsonPatch.Replace("/TotalMinutes", 40);
            db.Database.EnsureDeleted();
            db.Albums.Add(

                new Album()
                {
                    ID = 1,
                    Name = "Is This It",
                    ReleaseYear = new DateTime(2002, 10, 18),
                    TotalMinutes = 35.00,
                    PricePence = 1000,
                    ImgURL = "AlbumCover3"
                });
            db.SaveChanges();

            AlbumRepository albumRepository = new AlbumRepository(db);

            //Act
            var result = albumRepository.UpdateAlbumDetails(2, jsonPatch);

            //Assert

            result.Should().BeNull();


        }

        [Test]
        public void InsertAlbum_ReturnsNewAlbum()
        {

            //Arrange
            DbContextOptionsBuilder<RecordShopDbContext> dbOptionsBuilder = new DbContextOptionsBuilder<RecordShopDbContext>().UseInMemoryDatabase("InMemoryDb");
            RecordShopDbContext db = new RecordShopDbContext(dbOptionsBuilder.Options);
            db.Database.EnsureDeleted();
            AlbumDTO album = new AlbumDTO
            {
                Name = "Rushmere",
                ReleaseYear = DateTime.Parse("2025-03-28T12:04:16.514Z"),
                TotalMinutes = 34.18,
                ImgURL = "https://i.scdn.co/image/ab67616d0000b2731c75d1c5b466b7cb26a182cb",
                Artists = new List<string> { "Mumford & Sons" },
                Genres = new List<string> { "Folk", "Alternative", "Indie" },
                Songs = new List<Song>
                    {
                        new Song { Name = "Malibu", Duration = 4.02 },
                        new Song { Name = "Caroline", Duration = 3.20 },
                        new Song { Name = "Rushmere", Duration = 3.12 },
                        new Song { Name = "Monochrome", Duration = 3.04 },
                        new Song { Name = "Truth", Duration = 3.43 },
                        new Song { Name = "Where It Belongs", Duration = 4.07 },
                        new Song { Name = "Anchor", Duration = 2.51 },
                        new Song { Name = "Surrender", Duration = 3.10 },
                        new Song { Name = "Blood on the Page", Duration = 3.06 },
                        new Song { Name = "Carry On", Duration = 3.43 }
                    }
            };


            AlbumRepository albumRepository = new AlbumRepository(db);

            //Act
            var result = albumRepository.AddAlbum(album);

            //Assert
            db.Albums.Count().Should().Be(1);
            result.Should().BeEquivalentTo(new AlbumDTO
            {
                Name = "Rushmere",
                ReleaseYear = DateTime.Parse("2025-03-28T12:04:16.514Z"),
                TotalMinutes = 34.18,
                ImgURL = "https://i.scdn.co/image/ab67616d0000b2731c75d1c5b466b7cb26a182cb",
                Artists = new List<string> { "Mumford & Sons" },
                Genres = new List<string> { "Folk", "Alternative", "Indie" },
                Songs = new List<Song>
                    {
                        new Song { Name = "Malibu", Duration = 4.02 },
                        new Song { Name = "Caroline", Duration = 3.20 },
                        new Song { Name = "Rushmere", Duration = 3.12 },
                        new Song { Name = "Monochrome", Duration = 3.04 },
                        new Song { Name = "Truth", Duration = 3.43 },
                        new Song { Name = "Where It Belongs", Duration = 4.07 },
                        new Song { Name = "Anchor", Duration = 2.51 },
                        new Song { Name = "Surrender", Duration = 3.10 },
                        new Song { Name = "Blood on the Page", Duration = 3.06 },
                        new Song { Name = "Carry On", Duration = 3.43 }
                    }
            });


        }

    }
}