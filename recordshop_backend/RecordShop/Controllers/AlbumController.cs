using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RecordShop.Models;
using RecordShop.Services;
using JsonPatchDocument = Microsoft.AspNetCore.JsonPatch.JsonPatchDocument;


namespace RecordShop.Controllers
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("/[controller]")]
    public class AlbumsController(IAlbumService service) : ControllerBase
    {
        private readonly IAlbumService _service = service;

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllAlbums()
        {

            var albums = await _service.RetrieveAllAlbumsAsync();
            return albums.IsNullOrEmpty() ? NoContent() : Ok(albums);

        }

        [AllowAnonymous]
        [HttpGet("search")]
        public async Task<IActionResult> GetAlbumsByQuery([FromQuery] string q)
        {
            var albumsData = await _service.RetrieveFilteredAlbumsAsync(q);
            return albumsData.IsNullOrEmpty() ? NoContent() : Ok(albumsData);

        }

        [AllowAnonymous]
        [HttpGet("New")]
        public async Task<IActionResult> GetLatestReleases()
        {

            var albums = await _service.RetrieveNewReleasesAsync();
            return albums.IsNullOrEmpty() ? NoContent() : Ok(albums);

        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAlbumById(int id)
        {
            var album = await _service.RetrieveAlbumByIDAsync(id);
            return album is null ? NotFound() : Ok(album);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlbumById(int id)
        {
            bool deleteResult = await _service.AlbumDeletedAsync(id);
            return deleteResult ? NoContent() : NotFound();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchAlbumById(int id, JsonPatchDocument jsonPatch)
        {
            Album patchResult = await _service.UpdateAlbumAsync(id, jsonPatch);
            return patchResult is null ? NotFound() : Ok(patchResult);
        }

        [HttpPost]
        public async Task<IActionResult> PostAlbum(AlbumDTO album)
        {
            try
            {
                var albumData = await _service.AddNewAlbumAsync(album);
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
