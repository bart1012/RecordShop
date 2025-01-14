using Microsoft.AspNetCore.Mvc;
using RecordShop.Services;

namespace RecordShop.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class AlbumsController(AlbumService service) : ControllerBase
    {
        private readonly AlbumService _service = service;

        [HttpGet]
        public IActionResult GetAllAlbums()
        {
            return Ok(_service.RetrieveAllAlbums());
        }


    }
}
