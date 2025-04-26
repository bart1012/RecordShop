using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RecordShop.Models;
using RecordShop.Services;
using JsonPatchDocument = Microsoft.AspNetCore.JsonPatch.JsonPatchDocument;


namespace RecordShop.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class AlbumsController(IAlbumService service) : ControllerBase
    {
        private readonly IAlbumService _service = service;

        [HttpGet]
        public IActionResult GetAllAlbums()
        {

            var albums = _service.RetrieveAllAlbums();
            return albums.IsNullOrEmpty() ? NoContent() : Ok(albums);

        }

        [HttpGet("search/{q}")]
        public IActionResult GetAlbumsByQuery(string q)
        {
            var albumsData = _service.RetrieveAlbumsByQuery(q);
            return albumsData.IsNullOrEmpty() ? NoContent() : Ok(albumsData);

        }

        [HttpGet("New")]
        public IActionResult GetLatestReleases()
        {

            var albums = _service.RetrieveNewReleases();
            return albums.IsNullOrEmpty() ? NoContent() : Ok(albums);

        }

        [HttpGet("{id}")]
        public IActionResult GetAlbumById(int id)
        {
            var album = _service.RetrieveAlbumByID(id);
            return album is null ? NotFound() : Ok(album);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAlbumById(int id)
        {
            bool deleteResult = _service.DeleteAlbum(id);
            return deleteResult ? NoContent() : NotFound();
        }

        [HttpPatch("{id}")]
        public IActionResult PatchAlbumById(int id, JsonPatchDocument jsonPatch)
        {
            Album patchResult = _service.UpdateAlbum(id, jsonPatch);
            return patchResult is null ? NotFound() : Ok(patchResult);
            //if failed, notFound, badRequest, Conflict
        }

        [HttpPost]
        public IActionResult PostAlbum(AlbumDTO album)
        {
            try
            {
                var albumData = _service.AddNewAlbum(album);
                string uri = $"https://localhost:7195/Albums/{albumData.ID}";
                return Created(uri, album);

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

    }
}
