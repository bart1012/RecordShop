using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            bool isTaken = await _manager.Users.AnyAsync(u => u.Email == email);
            return Ok(new
            {
                Email = email,
                Availability = isTaken ? "taken" : "available"
            });
        }

    }
}
