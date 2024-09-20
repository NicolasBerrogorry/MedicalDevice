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
        [HttpPost]
        public async Task<ActionResult<User>> CreateUser([FromBody] User user)
        {
            user.Id = Ulid.NewUlid();

            context.Add(user);
            await context.SaveChangesAsync();

            return Ok(user);
        }

        [HttpPatch, Route("{id}")]
        public async Task<ActionResult<User>> UpdateUser([FromRoute] Ulid id, [FromBody] User user)
        {
            var existingUser = await context.Users.FindAsync(id);
            if (existingUser is null) return NotFound($"Could not find user with id {id}");

            existingUser.PhotoId = user.PhotoId;
            existingUser.Initials = user.Initials;
            existingUser.Name = user.Name;
            existingUser.Role = user.Role;
            existingUser.Description = user.Description;

            await context.SaveChangesAsync();

            return Ok(existingUser);
        }

        [HttpGet, Route("{id}")]
        public async Task<ActionResult<User>> GetUser([FromRoute] Ulid id)
        {
            var user = await context.Users.FindAsync(id);

            if (user is null) return NotFound($"Could not find user with id {id}");

            return Ok(user);
        }

        [HttpGet, Route("all")]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            var users = await context.Users
                .ToListAsync();
            return Ok(users);
        }


        [HttpPost, Route("{id}/set-current")]
        public async Task<ActionResult<User>> SetCurrentUser([FromRoute] Ulid id)
        {
            var user = await context.Users.FindAsync(id);
            if (user is null) return NotFound($"Could not find user with id {id}");

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
    }
}