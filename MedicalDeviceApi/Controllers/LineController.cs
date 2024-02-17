using MedicalDevice.Domain.Entities;
using MedicalDevice.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalDevice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LineController(DomainContext context) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetLines()
        {
            var lines = context.Lines.ToList();
            return Ok(lines);
        }

        [HttpPost]
        public async Task<IActionResult> AddLine([FromBody] Line line)
        {
            context.Lines.Add(line);
            await context.SaveChangesAsync();
            return Ok(line);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLine(int id)
        {
            var lineId = await context.Lines.FindAsync(id);
            if (lineId == null)
            {
                return NotFound();
            }
            return Ok(lineId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLine(int id, [FromBody] Line updatedLine)
        {
            var line = await context.Lines.FindAsync(id);
            if (line == null)
            {
                return NotFound();
            }

            line.DeviceSize = updatedLine.DeviceSize;

            await context.SaveChangesAsync();
            return Ok(line);
        }
    }
}