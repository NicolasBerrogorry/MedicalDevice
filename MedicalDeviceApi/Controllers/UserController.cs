using MedicalDevice.Database;
using MedicalDevice.Model;
using MedicalDevice.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MedicalDevice.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController(DatabaseContext context, SessionService session) : ControllerBase
    {
        [HttpPost, Route("current")]
        public async Task<ActionResult<User>> SetCurrentUser(Ulid id)
        {
            var user = await context.Users.FindAsync(id);
            if (user is null) return NotFound($"Could not find ticket with id {id}");

            session.SetUserId(id);

            return Ok(user);
        }

        [HttpGet, Route("current")]
        public async Task<ActionResult<User>> GetCurrentUser()
        {
            var userId = session.GetUserId();

            var user = await context.Users.FindAsync(userId);
            if (user is null) return NotFound($"Could not find user with id {userId}");
            return Ok(user);
        }

        [HttpGet, Route("all")]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            var users = await context.Users
                .ToListAsync();
            return Ok(users);
        }
    }
}