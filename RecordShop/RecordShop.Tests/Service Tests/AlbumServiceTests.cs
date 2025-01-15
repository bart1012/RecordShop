using FluentAssertions;
using Moq;
using RecordShop.Classes;
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
            mockAlbumRepository.Setup(repo => repo.GetAllAlbums()).Returns(new List<Album>()
            {
                new Album()
                {
                    Name = "Is This It",
                    ArtistID = 3,
                    ReleaseDate = 2001,
                    TotalMinutes = 36.28
                },
                new Album()
                {
                    Name = "OK Computer",
                    ArtistID = 2,
                    ReleaseDate = 1997,
                    TotalMinutes = 53.25
                },
                new Album()
                {
                    Name = "In the Aeroplane Over the Sea",
                    ArtistID = 1,
                    ReleaseDate = 1998,
                    TotalMinutes = 39.45
                }

            });

            //Act

            var result = albumService.RetrieveAllAlbums();

            //Assert
            mockAlbumRepository.Verify(repo => repo.GetAllAlbums(), Times.Once);
            result.Should().BeEquivalentTo(new List<Album>()
            {
                new Album()
                {
                    Name = "Is This It",
                    ArtistID = 3,
                    ReleaseDate = 2001,
                    TotalMinutes = 36.28
                },
                new Album()
                {
                    Name = "OK Computer",
                    ArtistID = 2,
                    ReleaseDate = 1997,
                    TotalMinutes = 53.25
                },
                new Album()
                {
                    Name = "In the Aeroplane Over the Sea",
                    ArtistID = 1,
                    ReleaseDate = 1998,
                    TotalMinutes = 39.45
                }

            });

        }

        [Test]
        public void RetrieveAllAlbums_ReturnsEmptyList()
        {
            //Arrange
            Mock<IAlbumRepository> mockAlbumRepository = new Mock<IAlbumRepository>();
            AlbumService albumService = new(mockAlbumRepository.Object);
            mockAlbumRepository.Setup(repo => repo.GetAllAlbums()).Returns(new List<Album>());

            //Act

            var result = albumService.RetrieveAllAlbums();

            //Assert
            mockAlbumRepository.Verify(repo => repo.GetAllAlbums(), Times.Once);
            result.Should().BeEquivalentTo(new List<Album>());

        }

        [Test]
        public void RetrieveAlbumById_ReturnsAlbumObjectWithMatchingID()
        {
            //Arrange
            Mock<IAlbumRepository> mockAlbumRepository = new Mock<IAlbumRepository>();
            AlbumService albumService = new(mockAlbumRepository.Object);
            mockAlbumRepository.Setup(repo => repo.GetAlbumByID(1)).Returns(

                new Album()
                {
                    ID = 1,
                    Name = "Is This It",
                    ArtistID = 3,
                    ReleaseDate = 2001,
                    TotalMinutes = 36.28
                }

            );
            //Act

            var result = albumService.RetrieveAlbumByID(1);

            //Assert
            mockAlbumRepository.Verify(repo => repo.GetAlbumByID(1), Times.Once);
            result.Should().BeEquivalentTo(new Album()
            {
                ID = 1,
                Name = "Is This It",
                ArtistID = 3,
                ReleaseDate = 2001,
                TotalMinutes = 36.28
            });

        }

        [Test]
        public void RetrieveAlbumById_ReturnsNull()
        {
            //Arrange
            Mock<IAlbumRepository> mockAlbumRepository = new Mock<IAlbumRepository>();
            AlbumService albumService = new(mockAlbumRepository.Object);
            mockAlbumRepository.Setup(repo => repo.GetAlbumByID(1)).Returns((Album?)null);

            //Act

            var result = albumService.RetrieveAlbumByID(1);

            //Assert
            mockAlbumRepository.Verify(repo => repo.GetAlbumByID(1), Times.Once);
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
            jsonPatch.Replace("/ReleaseDate", 2000).Replace("/ArtistID", 2);
            mockAlbumRepository.Setup(repo => repo.UpdateAlbumDetails(1, jsonPatch)).Returns(new Album()
            {
                ID = 1,
                Name = "In the Aeroplane Over the Sea",
                ArtistID = 2,
                ReleaseDate = 2000,
                TotalMinutes = 40.00,
            });

            //Act

            var result = albumService.UpdateAlbum(1, jsonPatch);

            //Assert
            mockAlbumRepository.Verify(repo => repo.UpdateAlbumDetails(1, jsonPatch), Times.Once);
            result.Should().BeEquivalentTo(new Album()
            {
                ID = 1,
                Name = "In the Aeroplane Over the Sea",
                ArtistID = 2,
                ReleaseDate = 2000,
                TotalMinutes = 40.00,
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