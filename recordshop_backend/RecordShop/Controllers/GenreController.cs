using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RecordShop.Backend.Services;

namespace RecordShop.Controllers
{
    [ApiController]
    [Route("/[controller]s")]
    public class GenreController(IGenreService gService) : ControllerBase
    {
        private readonly IGenreService _gService = gService;

        [HttpGet]
        public IActionResult GetAllGenres()
        {
            var result = _gService.RetrieveAllGenreNames();
            return result.IsNullOrEmpty() ? NoContent() : Ok(result);
        }

        [HttpPost]
        public IActionResult PostNewGenre(string gName)
        {
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteGenreById(int id)
        {
            return Ok();
        }

        [HttpPatch]
        public IActionResult PatchGenreById(int id, JsonPatchDocument jsonPatch)
        {
            return Ok();
        }

    }
}
