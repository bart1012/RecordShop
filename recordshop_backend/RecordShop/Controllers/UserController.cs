using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RecordShop.Backend.Models;
using RecordShop.Backend.Services;

namespace RecordShop.Backend.Controllers
{
    [ApiController]
    [Route("/[controller]")]

    public class UserController(IUserService service) : ControllerBase
    {
        private readonly IUserService _service = service;

        [HttpGet]

        public IActionResult GetAllUsers()
        {
            var userData = _service.RetrieveAllUserData();
            return userData.IsNullOrEmpty() ? NoContent() : Ok(userData);
        }

        [HttpPost]

        public IActionResult PostUser(User user)
        {
            try
            {
                var userData = _service.AddUser(user);
                return Created("", userData);

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("/login")]
        public IActionResult PostLoginDetails(string email, string password)
        {
            var user = _service.Login(email, password);
            if (user is null) return Unauthorized("Invalid credentials");
            return Ok();
        }

        [HttpDelete]

        public IActionResult DeleteUser(int id)
        {
            try
            {
                bool isDeleted = _service.DeleteUser(id);
                return NoContent();

            }
            catch (Exception e)
            {
                return NotFound();
            }
        }

    }
}
