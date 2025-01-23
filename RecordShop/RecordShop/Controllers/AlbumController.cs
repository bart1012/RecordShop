using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RecordShop.Classes;
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
            List<Album> dbAlbumData = _service.RetrieveAllAlbums();
            if (dbAlbumData.IsNullOrEmpty()) return NoContent();
            else return Ok(dbAlbumData);
        }

        [HttpGet("{id}")]
        public IActionResult GetAlbumById(int id)
        {
            Album dbAlbumData = _service.RetrieveAlbumByID(id);
            if (dbAlbumData is null) return NoContent();
            else return Ok(dbAlbumData);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAlbumById(int id)
        {
            bool deleteResult = _service.DeleteAlbum(id);
            if (deleteResult) return Ok();
            else return BadRequest("Album not found");
        }

        [HttpPatch("{id}")]
        public IActionResult PatchAlbumById(int id, JsonPatchDocument jsonPatch)
        {
            Album patchResult = _service.UpdateAlbum(id, jsonPatch);
            if (patchResult != null) return Ok(patchResult);
            else return BadRequest();
        }

        [HttpPost]
        public IActionResult PostAlbum(Album album)
        {
            Album postResult = _service.AddNewAlbum(album);
            if (postResult != null) return Ok(postResult);
            else return BadRequest();
        }

    }
}
