using MedicalDevice.Domain.Entities;
using MedicalDevice.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalDevice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TechnicianController(DomainContext context) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetTechnicians()
        {
            var technicians = context.Technicians.ToList();
            return Ok(technicians);
        }

        [HttpPost]
        public async Task<IActionResult> AddTechnician([FromBody] Technician technician)
        {
            context.Technicians.Add(technician);
            await context.SaveChangesAsync();
            return Ok(technician);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTechnician(int id)
        {
            var technician = await context.Technicians.FindAsync(id);
            if (technician == null)
            {
                return NotFound();
            }
            return Ok(technician);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTechnician(int id, [FromBody] Technician updatedTechnician)
        {
            var technician = await context.Technicians.FindAsync(id);
            if (technician == null)
            {
                return NotFound();
            }

            technician.Name = updatedTechnician.Name;

            await context.SaveChangesAsync();
            return Ok(technician);
        }
    }
}