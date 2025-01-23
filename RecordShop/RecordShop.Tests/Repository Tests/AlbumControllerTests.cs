global using JsonPatchDocument = Microsoft.AspNetCore.JsonPatch.JsonPatchDocument;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using RecordShop.Classes;
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
            AlbumRepository albumRepository = new AlbumRepository(db);

            //Act
            var result = albumRepository.GetAllAlbums();
            db.Database.EnsureDeleted();

            //Assert
            result.Should().BeEquivalentTo(new List<Album>()
            {
                 new Album()
                {
                    ID = 1,
                    Name = "In the Aeroplane Over the Sea",
                    ArtistID = 1,
                    ReleaseDate = 1998,
                    TotalMinutes = 39.45,
                },

                new Album()
                {
                    ID = 2,
                    Name = "OK Computer",
                    ArtistID = 2,
                    ReleaseDate = 1997,
                    TotalMinutes = 53.25,
                },

                new Album
                {
                    ID = 3,
                    Name = "Is This It",
                    ArtistID = 3,
                    ReleaseDate = 2001,
                    TotalMinutes = 36.28,
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
            var result = albumRepository.GetAllAlbums();

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
                    Name = "In the Aeroplane Over the Sea",
                    ArtistID = 1,
                    ReleaseDate = 1998,
                    TotalMinutes = 39.45,
                });

            db.SaveChanges();

            AlbumRepository albumRepository = new AlbumRepository(db);

            //Act
            var result = albumRepository.GetAlbumByID(1);

            //Assert
            result.Should().BeEquivalentTo(new Album()
            {
                ID = 1,
                Name = "In the Aeroplane Over the Sea",
                ArtistID = 1,
                ReleaseDate = 1998,
                TotalMinutes = 39.45,
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
            var result = albumRepository.GetAlbumByID(1);

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
                    Name = "In the Aeroplane Over the Sea",
                    ArtistID = 1,
                    ReleaseDate = 1998,
                    TotalMinutes = 39.45,
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
                    Name = "In the Aeroplane Over the Sea",
                    ArtistID = 1,
                    ReleaseDate = 1998,
                    TotalMinutes = 39.45,
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
                    Name = "In the Aeroplane Over the Sea",
                    ArtistID = 1,
                    ReleaseDate = 1998,
                    TotalMinutes = 39.45,
                });
            db.SaveChanges();

            AlbumRepository albumRepository = new AlbumRepository(db);

            //Act
            var result = albumRepository.UpdateAlbumDetails(1, jsonPatch);

            //Assert

            result.Should().BeEquivalentTo(new Album()
            {
                ID = 1,
                Name = "In the Aeroplane Over the Sea",
                ArtistID = 1,
                ReleaseDate = 1998,
                TotalMinutes = 40.00,
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
                    Name = "In the Aeroplane Over the Sea",
                    ArtistID = 1,
                    ReleaseDate = 1998,
                    TotalMinutes = 39.45,
                });
            db.SaveChanges();

            AlbumRepository albumRepository = new AlbumRepository(db);

            //Act
            var result = albumRepository.UpdateAlbumDetails(2, jsonPatch);

            //Assert

            result.Should().BeNull();


        }

        [Test]
        public void InsertALbum_ReturnsNewAlbum()
        {

            //Arrange
            DbContextOptionsBuilder<RecordShopDbContext> dbOptionsBuilder = new DbContextOptionsBuilder<RecordShopDbContext>().UseInMemoryDatabase("InMemoryDb");
            RecordShopDbContext db = new RecordShopDbContext(dbOptionsBuilder.Options);
            db.Database.EnsureDeleted();
            Album album = new Album()
            {
                Name = "In the Aeroplane Over the Sea",
                ArtistID = 1,
                ReleaseDate = 1998,
                TotalMinutes = 39.45,
            };

            AlbumRepository albumRepository = new AlbumRepository(db);

            //Act
            var result = albumRepository.InsertAlbum(album);

            //Assert
            db.Albums.Count().Should().Be(1);
            result.Should().BeEquivalentTo(new Album()
            {
                ID = 1,
                Name = "In the Aeroplane Over the Sea",
                ArtistID = 1,
                ReleaseDate = 1998,
                TotalMinutes = 39.45,
            });


        }

    }
}