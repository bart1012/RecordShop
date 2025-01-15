using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using RecordShop.Classes;
using RecordShop.Controllers;
using RecordShop.Services;
namespace RecordShop.Tests
{
    public class ControllerTests
    {
        private DbContextOptions dbOptions = new DbContextOptionsBuilder<RecordShopDbContext>()
            .UseInMemoryDatabase(databaseName: "AlbumListDatabase")
            .Options;

        [Test]
        public void GetAllAlbums_ReturnsOkWithAlbumList()
        {
            //Arrange
            Mock<IAlbumService> mockAlbumService = new Mock<IAlbumService>();
            AlbumsController albumsController = new(mockAlbumService.Object);
            mockAlbumService.Setup(service => service.RetrieveAllAlbums()).Returns(new List<Album>()
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
            var result = albumsController.GetAllAlbums() as ObjectResult;
            var resultValue = result.Value as List<Album>;

            //Assert
            mockAlbumService.Verify(service => service.RetrieveAllAlbums(), Times.Once);
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
            resultValue.Should().NotBeEmpty();
            resultValue.Should().BeEquivalentTo(new List<Album>()
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
        public void GetAllAlbums_ReturnsNoContentIfServiceResultIsEmpty()
        {
            //Arrange
            Mock<IAlbumService> mockAlbumService = new Mock<IAlbumService>();
            AlbumsController albumsController = new(mockAlbumService.Object);
            mockAlbumService.Setup(service => service.RetrieveAllAlbums()).Returns(new List<Album>());

            //Act
            var result = albumsController.GetAllAlbums();
            var resultObj = result as ObjectResult;

            //Assert
            result.Should().BeOfType<NoContentResult>();
            mockAlbumService.Verify(service => service.RetrieveAllAlbums(), Times.Once);

        }

        [Test]
        public void GetAlbumByID_ReturnsOkWithAlbum()
        {
            //Arrange
            Mock<IAlbumService> mockAlbumService = new Mock<IAlbumService>();
            AlbumsController albumsController = new(mockAlbumService.Object);
            mockAlbumService.Setup(service => service.RetrieveAlbumByID(1)).Returns(new Album()
            {
                ID = 1,
                Name = "In the Aeroplane Over the Sea",
                ArtistID = 1,
                ReleaseDate = 1998,
                TotalMinutes = 39.45,
            });

            //Act
            var result = albumsController.GetAlbumById(1) as ObjectResult;

            //Assert
            mockAlbumService.Verify(service => service.RetrieveAlbumByID(1), Times.Once);
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
            result.Value.Should().BeEquivalentTo(new Album()
            {
                ID = 1,
                Name = "In the Aeroplane Over the Sea",
                ArtistID = 1,
                ReleaseDate = 1998,
                TotalMinutes = 39.45,
            });
        }

        [Test]
        public void GetAlbumByID_ReturnsNoContentIfServiceResultIsNull()
        {
            //Arrange
            Mock<IAlbumService> mockAlbumService = new Mock<IAlbumService>();
            AlbumsController albumsController = new(mockAlbumService.Object);
            mockAlbumService.Setup(service => service.RetrieveAlbumByID(1)).Returns((Album?)null);

            //Act
            var result = albumsController.GetAlbumById(1);

            //Assert
            mockAlbumService.Verify(service => service.RetrieveAlbumByID(1), Times.Once);
            result.Should().BeOfType<NoContentResult>();
        }

        [Test]
        public void DeleteAlbumById_ReturnsOk()
        {
            //Arrange
            Mock<IAlbumService> mockAlbumService = new Mock<IAlbumService>();
            AlbumsController albumsController = new(mockAlbumService.Object);
            mockAlbumService.Setup(service => service.DeleteAlbum(1)).Returns(true);

            //Act
            var result = albumsController.DeleteAlbumById(1);

            //Assert
            mockAlbumService.Verify(service => service.DeleteAlbum(1), Times.Once);
            result.Should().BeOfType<OkResult>();
        }

        [Test]
        public void DeleteAlbumById_ReturnsBadRequest()
        {
            //Arrange
            Mock<IAlbumService> mockAlbumService = new Mock<IAlbumService>();
            AlbumsController albumsController = new(mockAlbumService.Object);
            mockAlbumService.Setup(service => service.DeleteAlbum(1)).Returns(false);

            //Act
            var result = albumsController.DeleteAlbumById(1) as ObjectResult;

            //Assert
            mockAlbumService.Verify(service => service.DeleteAlbum(1), Times.Once);
            result.StatusCode.Should().Be(StatusCodes.Status400BadRequest);
        }

        [Test]
        public void PatchAlbumById_ReturnsUpdatedAlbum()
        {
            //Arrange
            Mock<IAlbumService> mockAlbumService = new Mock<IAlbumService>();
            AlbumsController albumsController = new(mockAlbumService.Object);
            JsonPatchDocument jsonPatch = new JsonPatchDocument();
            jsonPatch.Replace("/TotalMinutes", 40);
            mockAlbumService.Setup(service => service.UpdateAlbum(1, jsonPatch)).Returns(new Album()
            {
                ID = 1,
                Name = "In the Aeroplane Over the Sea",
                ArtistID = 1,
                ReleaseDate = 1998,
                TotalMinutes = 40.00,
            });

            //Act
            var result = albumsController.PatchAlbumById(1, jsonPatch) as OkObjectResult;

            //Assert
            mockAlbumService.Verify(service => service.UpdateAlbum(1, jsonPatch), Times.Once);
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
            result.Value.Should().BeEquivalentTo(new Album()
            {
                ID = 1,
                Name = "In the Aeroplane Over the Sea",
                ArtistID = 1,
                ReleaseDate = 1998,
                TotalMinutes = 40.00,
            });
        }

        [Test]
        public void PatchAlbumById_ReturnsBadRequest()
        {
            //Arrange
            Mock<IAlbumService> mockAlbumService = new Mock<IAlbumService>();
            AlbumsController albumsController = new(mockAlbumService.Object);
            JsonPatchDocument jsonPatch = new JsonPatchDocument();
            jsonPatch.Replace("/TotalMinutes", 40);
            mockAlbumService.Setup(service => service.UpdateAlbum(1, jsonPatch)).Returns((Album?)null);

            //Act
            var result = albumsController.PatchAlbumById(1, jsonPatch);

            //Assert
            mockAlbumService.Verify(service => service.UpdateAlbum(1, jsonPatch), Times.Once);
            result.Should().BeOfType<BadRequestResult>();
        }
    }
}