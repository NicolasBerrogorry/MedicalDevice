using MedicalDevice.Database;
using MedicalDevice.Model;
using MedicalDevice.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MedicalDevice.Controllers
{
    [ApiController]
    [Route("device")]
    public class DeviceController(DatabaseContext context, SessionService session) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Device>>> GetAllDevices()
        {
            var devices = await context.Devices
                .ToListAsync();
            return Ok(devices);
        }

        [HttpGet, Route("{id}")]
        public async Task<ActionResult<TicketEntry>> GetDevice([FromRoute] Ulid id)
        {
            var entry = await context.TicketEntries.FindAsync(id);
            if (entry is null) return NotFound($"Could not find entry with id {id}");

            return Ok(entry);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDevice([FromBody] Device device)
        {
            device.Id = Ulid.NewUlid();
            device.CreationDate = DateTime.Now;
            device.CreationUserId = session.GetUserId();

            context.Add(device);
            await context.SaveChangesAsync();

            return Ok(device);
        }
    }
}