using MedicalDevice.Domain.Entities;
using MedicalDevice.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalDevice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ModelController(DomainContext context) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetTechnicians()
        {
            var models = context.Models.ToList();
            return Ok(models);
        }

        [HttpPost]
        public async Task<IActionResult> AddTechnician([FromBody] Model model)
        {
            context.Models.Add(model);
            await context.SaveChangesAsync();
            return Ok(model);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTechnician(int id)
        {
            var model = await context.Models.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTechnician(int id, [FromBody] Model updatedModel)
        {
            var model = await context.Models.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            model.Name = updatedModel.Name;

            await context.SaveChangesAsync();
            return Ok(model);
        }
    }
}