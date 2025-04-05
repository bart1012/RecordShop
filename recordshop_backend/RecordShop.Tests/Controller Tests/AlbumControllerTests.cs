using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using RecordShop.Backend.DbContexts;
using RecordShop.Controllers;
using RecordShop.Models;
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
            mockAlbumService.Setup(service => service.RetrieveAllAlbums()).Returns(new List<AlbumDTO>()
            {
                new AlbumDTO()
                {
                    ID=1,
                    Name = "OK Computer",
                    ReleaseYear = new DateTime(1997,06,16),
                    TotalMinutes = 53,
                    ImgURL = "https://i.scdn.co/image/ab67616d0000b273c8b444df094279e70d0ed856",
                    Artists = ["Radiohead"],
                    Genres = [ "Alternative Rock", "Electronic"],
                    Songs = [
                            new Song { ID = 1, Name = "Airbag", Duration = 4.43 },
                            new Song { ID = 2, Name = "Paranoid Android", Duration = 6.23 },
                            new Song { ID = 3, Name = "Subterranean Homesick Alien", Duration = 4.27 },
                            new Song { ID = 4, Name = "Exit Music (For a Film)", Duration = 4.24 },
                            new Song { ID = 5, Name = "Let Down", Duration = 4.59 },
                            new Song { ID = 6, Name = "Karma Police", Duration = 4.21 },
                            new Song { ID = 7, Name = "Fitter Happier", Duration = 1.57 },
                            new Song { ID = 8, Name = "Electioneering", Duration = 3.5 },
                            new Song { ID = 9, Name = "Climbing Up the Walls", Duration = 4.45 },
                            new Song { ID = 10, Name = "No Surprises", Duration = 3.49 },
                            new Song { ID = 11, Name = "Lucky", Duration = 4.19 }
                        ]
                }

            });

            //Act
            var result = albumsController.GetAllAlbums() as ObjectResult;
            var resultValue = result.Value as List<AlbumDTO>;

            //Assert
            mockAlbumService.Verify(service => service.RetrieveAllAlbums(), Times.Once);
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
            resultValue.Should().NotBeEmpty();
            resultValue.Should().BeEquivalentTo(new List<AlbumDTO>()
            {
                 new AlbumDTO()
                {
                    ID=1,
                    Name = "OK Computer",
                    ReleaseYear = new DateTime(1997,06,16),
                    TotalMinutes = 53,
                    ImgURL = "https://i.scdn.co/image/ab67616d0000b273c8b444df094279e70d0ed856",
                    Artists = ["Radiohead"],
                    Genres = [ "Alternative Rock", "Electronic"],
                    Songs = [
                            new Song { ID = 1, Name = "Airbag", Duration = 4.43 },
                            new Song { ID = 2, Name = "Paranoid Android", Duration = 6.23 },
                            new Song { ID = 3, Name = "Subterranean Homesick Alien", Duration = 4.27 },
                            new Song { ID = 4, Name = "Exit Music (For a Film)", Duration = 4.24 },
                            new Song { ID = 5, Name = "Let Down", Duration = 4.59 },
                            new Song { ID = 6, Name = "Karma Police", Duration = 4.21 },
                            new Song { ID = 7, Name = "Fitter Happier", Duration = 1.57 },
                            new Song { ID = 8, Name = "Electioneering", Duration = 3.5 },
                            new Song { ID = 9, Name = "Climbing Up the Walls", Duration = 4.45 },
                            new Song { ID = 10, Name = "No Surprises", Duration = 3.49 },
                            new Song { ID = 11, Name = "Lucky", Duration = 4.19 }
                        ]
                }

            });
        }

        [Test]
        public void GetAllAlbums_ReturnsNoContentIfServiceResultIsEmpty()
        {
            //Arrange
            Mock<IAlbumService> mockAlbumService = new Mock<IAlbumService>();
            AlbumsController albumsController = new(mockAlbumService.Object);
            mockAlbumService.Setup(service => service.RetrieveAllAlbums()).Returns(new List<AlbumDTO>());

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
            mockAlbumService.Setup(service => service.RetrieveAlbumByID(1)).Returns(new AlbumDTO()
            {
                ID = 1,
                Name = "OK Computer",
                ReleaseYear = new DateTime(1997, 06, 16),
                TotalMinutes = 53,
                ImgURL = "https://i.scdn.co/image/ab67616d0000b273c8b444df094279e70d0ed856",
                Artists = ["Radiohead"],
                Genres = ["Alternative Rock", "Electronic"],
                Songs = [
                            new Song { ID = 1, Name = "Airbag", Duration = 4.43 },
                            new Song { ID = 2, Name = "Paranoid Android", Duration = 6.23 },
                            new Song { ID = 3, Name = "Subterranean Homesick Alien", Duration = 4.27 },
                            new Song { ID = 4, Name = "Exit Music (For a Film)", Duration = 4.24 },
                            new Song { ID = 5, Name = "Let Down", Duration = 4.59 },
                            new Song { ID = 6, Name = "Karma Police", Duration = 4.21 },
                            new Song { ID = 7, Name = "Fitter Happier", Duration = 1.57 },
                            new Song { ID = 8, Name = "Electioneering", Duration = 3.5 },
                            new Song { ID = 9, Name = "Climbing Up the Walls", Duration = 4.45 },
                            new Song { ID = 10, Name = "No Surprises", Duration = 3.49 },
                            new Song { ID = 11, Name = "Lucky", Duration = 4.19 }
                        ]
            });

            //Act
            var result = albumsController.GetAlbumById(1) as ObjectResult;

            //Assert
            mockAlbumService.Verify(service => service.RetrieveAlbumByID(1), Times.Once);
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
            result.Value.Should().BeEquivalentTo(new AlbumDTO()
            {
                ID = 1,
                Name = "OK Computer",
                ReleaseYear = new DateTime(1997, 06, 16),
                TotalMinutes = 53,
                ImgURL = "https://i.scdn.co/image/ab67616d0000b273c8b444df094279e70d0ed856",
                Artists = ["Radiohead"],
                Genres = ["Alternative Rock", "Electronic"],
                Songs = [
                            new Song { ID = 1, Name = "Airbag", Duration = 4.43 },
                            new Song { ID = 2, Name = "Paranoid Android", Duration = 6.23 },
                            new Song { ID = 3, Name = "Subterranean Homesick Alien", Duration = 4.27 },
                            new Song { ID = 4, Name = "Exit Music (For a Film)", Duration = 4.24 },
                            new Song { ID = 5, Name = "Let Down", Duration = 4.59 },
                            new Song { ID = 6, Name = "Karma Police", Duration = 4.21 },
                            new Song { ID = 7, Name = "Fitter Happier", Duration = 1.57 },
                            new Song { ID = 8, Name = "Electioneering", Duration = 3.5 },
                            new Song { ID = 9, Name = "Climbing Up the Walls", Duration = 4.45 },
                            new Song { ID = 10, Name = "No Surprises", Duration = 3.49 },
                            new Song { ID = 11, Name = "Lucky", Duration = 4.19 }
                        ]
            });
        }

        [Test]
        public void GetAlbumByID_ReturnsNotFoundIfServiceResultIsNull()
        {
            //Arrange
            Mock<IAlbumService> mockAlbumService = new Mock<IAlbumService>();
            AlbumsController albumsController = new(mockAlbumService.Object);
            mockAlbumService.Setup(service => service.RetrieveAlbumByID(14)).Returns((AlbumDTO?)null);

            //Act
            var result = albumsController.GetAlbumById(14) as NotFoundResult;

            //Assert
            mockAlbumService.Verify(service => service.RetrieveAlbumByID(14), Times.Once);
            result.StatusCode.Should().Be(StatusCodes.Status404NotFound);
        }

        [Test]
        public void DeleteAlbumById_ReturnsNoContent()
        {
            //Arrange
            Mock<IAlbumService> mockAlbumService = new Mock<IAlbumService>();
            AlbumsController albumsController = new(mockAlbumService.Object);
            mockAlbumService.Setup(service => service.DeleteAlbum(1)).Returns(true);

            //Act
            var result = albumsController.DeleteAlbumById(1) as NoContentResult;

            //Assert
            mockAlbumService.Verify(service => service.DeleteAlbum(1), Times.Once);
            result.StatusCode.Should().Be(StatusCodes.Status204NoContent);
        }

        [Test]
        public void DeleteAlbumById_ReturnsNotFound()
        {
            //Arrange
            Mock<IAlbumService> mockAlbumService = new Mock<IAlbumService>();
            AlbumsController albumsController = new(mockAlbumService.Object);
            mockAlbumService.Setup(service => service.DeleteAlbum(1)).Returns(false);

            //Act
            var result = albumsController.DeleteAlbumById(1) as NotFoundResult;

            //Assert
            mockAlbumService.Verify(service => service.DeleteAlbum(1), Times.Once);
            result.StatusCode.Should().Be(StatusCodes.Status404NotFound);
        }

        [Test]
        public void PatchAlbumById_ReturnsUpdatedAlbum()
        {
            //Arrange
            Mock<IAlbumService> mockAlbumService = new Mock<IAlbumService>();
            AlbumsController albumsController = new(mockAlbumService.Object);
            JsonPatchDocument jsonPatch = new JsonPatchDocument();
            jsonPatch.Replace("/TotalMinutes", 40);
            mockAlbumService.Setup(service => service.UpdateAlbum(1, jsonPatch)).Returns(
                new Album()
                {
                    ID = 1,
                    Name = "OK Computer",
                    ReleaseYear = new DateTime(1997, 06, 16),
                    TotalMinutes = 40.00,
                    PricePence = 1200,
                    ImgURL = "https://i.scdn.co/image/ab67616d0000b273c8b444df094279e70d0ed856"
                }
            );

            //Act
            var result = albumsController.PatchAlbumById(1, jsonPatch) as OkObjectResult;

            //Assert
            mockAlbumService.Verify(service => service.UpdateAlbum(1, jsonPatch), Times.Once);
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
            result.Value.Should().BeEquivalentTo(new Album()
            {
                ID = 1,
                Name = "OK Computer",
                ReleaseYear = new DateTime(1997, 06, 16),
                TotalMinutes = 40.00,
                PricePence = 1200,
                ImgURL = "https://i.scdn.co/image/ab67616d0000b273c8b444df094279e70d0ed856"
            });
        }

        [Test]
        public void PatchAlbumById_ReturnsNotFound()
        {
            //Arrange
            Mock<IAlbumService> mockAlbumService = new Mock<IAlbumService>();
            AlbumsController albumsController = new(mockAlbumService.Object);
            JsonPatchDocument jsonPatch = new JsonPatchDocument();
            jsonPatch.Replace("/TotalMinutes", 40);
            mockAlbumService.Setup(service => service.UpdateAlbum(55, jsonPatch)).Returns((Album?)null);

            //Act
            var result = albumsController.PatchAlbumById(1, jsonPatch) as NotFoundResult;

            //Assert
            mockAlbumService.Verify(service => service.UpdateAlbum(1, jsonPatch), Times.Once);
            result.StatusCode.Should().Be(StatusCodes.Status404NotFound);
        }
    }
}