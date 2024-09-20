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
        [HttpPost]
        public async Task<ActionResult<Device>> CreateDevice([FromBody] Device device)
        {
            device.Id = Ulid.NewUlid();
            device.CreationDate = DateTime.Now;

            var creationUserId = session.GetUserId();
            var creationUser = await context.Users.FindAsync(creationUserId);
            device.CreationUserId = creationUser?.Id ?? Ulid.Empty;
            device.CreationUser = creationUser;

            context.Add(device);
            await context.SaveChangesAsync();

            return Ok(device);
        }

        [HttpPatch, Route("{id}")]
        public async Task<ActionResult<Device>> UpdateDevice([FromRoute] Ulid id, [FromBody] Device device)
        {
            var existingDevice = await context.Devices.FindAsync(id);
            if (existingDevice is null) return NotFound($"Could not find device with id {id}");

            existingDevice.PhotoId = device.PhotoId;
            existingDevice.Model = device.Model;
            existingDevice.SerialNumber = device.SerialNumber;

            await context.SaveChangesAsync();

            return Ok(existingDevice);
        }

        [HttpGet, Route("{id}")]
        public async Task<ActionResult<Device>> GetDevice([FromRoute] Ulid id)
        {
            var device = await context.Devices
                .Include(d => d.CreationUser)
                .SingleOrDefaultAsync(d => d.Id == id);

            if (device is null) return NotFound($"Could not find device with id {id}");

            return Ok(device);
        }

        [HttpGet]
        public async Task<ActionResult<List<Device>>> GetAllDevices()
        {
            var devices = await context.Devices
                .Include(d => d.CreationUser)
                .ToListAsync();
            return Ok(devices);
        }
    }
}