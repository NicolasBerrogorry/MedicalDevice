using MedicalDevice.Domain.Entities;
using MedicalDevice.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalDevice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeviceController(DomainContext context) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetTechnicians()
        {
            var technicians = context.Devices.ToList();
            return Ok(technicians);
        }

        [HttpPost]
        public async Task<IActionResult> AddTechnician([FromBody] Device device)
        {
            context.Devices.Add(device);
            await context.SaveChangesAsync();
            return Ok(device);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDevice(int id)
        {
            var device = await context.Devices.FindAsync(id);
            if (device == null)
            {
                return NotFound();
            }
            return Ok(device);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDevice(int id, [FromBody] Device updatedDevice)
        {
            var device = await context.Devices.FindAsync(id);
            if (device == null)
            {
                return NotFound();
            }

            device.ModelId = updatedDevice.ModelId;

            await context.SaveChangesAsync();
            return Ok(device);
        }
    }
}