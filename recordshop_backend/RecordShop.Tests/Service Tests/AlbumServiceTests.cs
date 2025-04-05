using FluentAssertions;
using Moq;
using RecordShop.Models;
using RecordShop.Repositories;
using RecordShop.Services;
namespace RecordShop.Tests
{
    public class ServiceTests
    {

        [Test]
        public void RetrieveAllAlbums_ReturnsListOfAlbumObjects()
        {
            //Arrange
            Mock<IAlbumRepository> mockAlbumRepository = new Mock<IAlbumRepository>();
            AlbumService albumService = new(mockAlbumRepository.Object);
            mockAlbumRepository.Setup(repo => repo.RetrieveAllAlbums()).Returns(new List<Album>()
            {
                 new Album()
                {
                    Name = "In the Aeroplane Over the Sea",
                    ReleaseYear = new DateTime(1998,01,13),
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

            });

            //Act

            var result = albumService.RetrieveAllAlbums();

            //Assert
            mockAlbumRepository.Verify(repo => repo.RetrieveAllAlbums(), Times.Once);
            result.Should().BeEquivalentTo(new List<AlbumDTO>()
            {
                 new AlbumDTO()
                {
                    Name = "In the Aeroplane Over the Sea",
                    ReleaseYear = new DateTime(1998,01,13),
                    TotalMinutes = 39.45,
                    PricePence = 1200,
                    ImgURL = "AlbumCover1",
                    Artists = new List<string>(),
                    Genres = new List<string> (),
                    Songs = new List<Song>()

                },

                 new AlbumDTO()
                 {
                     Name = "Ok Computer",
                     ReleaseYear = new DateTime(1997, 10, 18),
                     TotalMinutes = 32.00,
                     PricePence = 1500,
                     ImgURL = "AlbumCover2",
                      Artists = new List<string>(),
                    Genres = new List<string> (),
                    Songs = new List<Song>()
                 },

                   new AlbumDTO()
                   {
                       Name = "Is This It",
                       ReleaseYear = new DateTime(2002, 10, 18),
                       TotalMinutes = 35.00,
                       PricePence = 1000,
                       ImgURL = "AlbumCover3",
                        Artists = new List<string>(),
                    Genres = new List<string> (),
                    Songs = new List<Song>()
                   }

            });

        }

        [Test]
        public void RetrieveAllAlbums_ReturnsEmptyList()
        {
            //Arrange
            Mock<IAlbumRepository> mockAlbumRepository = new Mock<IAlbumRepository>();
            AlbumService albumService = new(mockAlbumRepository.Object);
            mockAlbumRepository.Setup(repo => repo.RetrieveAllAlbums()).Returns(new List<Album>());

            //Act

            var result = albumService.RetrieveAllAlbums();

            //Assert
            mockAlbumRepository.Verify(repo => repo.RetrieveAllAlbums(), Times.Once);
            result.Should().BeEquivalentTo((List<AlbumDTO>)null);

        }

        [Test]
        public void RetrieveAlbumById_ReturnsAlbumObjectWithMatchingID()
        {
            //Arrange
            Mock<IAlbumRepository> mockAlbumRepository = new Mock<IAlbumRepository>();
            AlbumService albumService = new(mockAlbumRepository.Object);
            mockAlbumRepository.Setup(repo => repo.FindAlbumByID(1)).Returns(

                new Album()
                {
                    ID = 1,
                    Name = "In the Aeroplane Over the Sea",
                    ReleaseYear = new DateTime(1998, 01, 13),
                    TotalMinutes = 39.45,
                    PricePence = 1200,
                    ImgURL = "AlbumCover1"
                }

            );
            //Act

            var result = albumService.RetrieveAlbumByID(1);

            //Assert
            mockAlbumRepository.Verify(repo => repo.FindAlbumByID(1), Times.Once);
            result.Should().BeEquivalentTo(new AlbumDTO()
            {
                ID = 1,
                Name = "In the Aeroplane Over the Sea",
                ReleaseYear = new DateTime(1998, 01, 13),
                TotalMinutes = 39.45,
                PricePence = 1200,
                ImgURL = "AlbumCover1",
                Artists = new List<string>(),
                Genres = new List<string>(),
                Songs = new List<Song>()

            });

        }

        [Test]
        public void RetrieveAlbumById_ReturnsNull()
        {
            //Arrange
            Mock<IAlbumRepository> mockAlbumRepository = new Mock<IAlbumRepository>();
            AlbumService albumService = new(mockAlbumRepository.Object);
            mockAlbumRepository.Setup(repo => repo.FindAlbumByID(1)).Returns((Album?)null);

            //Act

            var result = albumService.RetrieveAlbumByID(1);

            //Assert
            mockAlbumRepository.Verify(repo => repo.FindAlbumByID(1), Times.Once);
            result.Should().BeNull();

        }

        [Test]
        public void DeleteAlbum_ReturnsTrue()
        {
            //Arrange
            Mock<IAlbumRepository> mockAlbumRepository = new Mock<IAlbumRepository>();
            AlbumService albumService = new(mockAlbumRepository.Object);
            mockAlbumRepository.Setup(repo => repo.DeleteAlbum(1)).Returns(true);

            //Act

            var result = albumService.DeleteAlbum(1);

            //Assert
            mockAlbumRepository.Verify(repo => repo.DeleteAlbum(1), Times.Once);
            result.Should().BeTrue();

        }

        [Test]
        public void DeleteAlbum_ReturnsFalse()
        {
            //Arrange
            Mock<IAlbumRepository> mockAlbumRepository = new Mock<IAlbumRepository>();
            AlbumService albumService = new(mockAlbumRepository.Object);
            mockAlbumRepository.Setup(repo => repo.DeleteAlbum(1)).Returns(false);

            //Act

            var result = albumService.DeleteAlbum(1);

            //Assert
            mockAlbumRepository.Verify(repo => repo.DeleteAlbum(1), Times.Once);
            result.Should().BeFalse();

        }

        [Test]
        public void UpdateAlbum_ReturnsUpdatedAlbum()
        {
            //Arrange
            Mock<IAlbumRepository> mockAlbumRepository = new Mock<IAlbumRepository>();
            AlbumService albumService = new(mockAlbumRepository.Object);
            JsonPatchDocument jsonPatch = new JsonPatchDocument();
            jsonPatch.Replace("/Name", "Ok Computer 10th Anniversary Edition");
            mockAlbumRepository.Setup(repo => repo.UpdateAlbumDetails(1, jsonPatch)).Returns(new Album()
            {
                ID = 1,
                Name = "Ok Computer 10th Anniversary Edition",
                ReleaseYear = new DateTime(1997, 10, 18),
                TotalMinutes = 32.00,
                PricePence = 1500,
                ImgURL = "AlbumCover2"
            });

            //Act

            var result = albumService.UpdateAlbum(1, jsonPatch);

            //Assert
            mockAlbumRepository.Verify(repo => repo.UpdateAlbumDetails(1, jsonPatch), Times.Once);
            result.Should().BeEquivalentTo(new Album()
            {
                ID = 1,
                Name = "Ok Computer 10th Anniversary Edition",
                ReleaseYear = new DateTime(1997, 10, 18),
                TotalMinutes = 32.00,
                PricePence = 1500,
                ImgURL = "AlbumCover2"
            });

        }

        [Test]
        public void UpdateAlbum_ReturnsNull()
        {
            //Arrange
            Mock<IAlbumRepository> mockAlbumRepository = new Mock<IAlbumRepository>();
            AlbumService albumService = new(mockAlbumRepository.Object);
            JsonPatchDocument jsonPatch = new JsonPatchDocument();
            jsonPatch.Replace("/ReleaseDate", 2000).Replace("/ArtistID", 2);
            mockAlbumRepository.Setup(repo => repo.UpdateAlbumDetails(1, jsonPatch)).Returns((Album?)null);

            //Act

            var result = albumService.UpdateAlbum(1, jsonPatch);

            //Assert
            mockAlbumRepository.Verify(repo => repo.UpdateAlbumDetails(1, jsonPatch), Times.Once);
            result.Should().BeNull();

        }
    }
}