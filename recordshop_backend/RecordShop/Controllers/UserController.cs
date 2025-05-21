using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace RecordShop.Backend.Controllers
{


    [ApiController]
    [Route("[controller]s")]
    public class UserController(UserManager<IdentityUser> manager) : ControllerBase
    {
        private readonly UserManager<IdentityUser> _manager = manager;

        [HttpGet("Email-Exists")]
        public async Task<IActionResult> CheckEmailIsTaken(string email)
        {
            return Ok(new
            {
                Email = email,
                Availability = _manager.Users.Any(u => u.Email == email) ? "taken" : "available"
            });
        }

    }
}
