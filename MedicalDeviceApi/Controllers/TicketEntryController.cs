using MedicalDevice.Database;
using MedicalDevice.Model;
using MedicalDevice.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MedicalDevice.Controllers
{
    [ApiController]
    public class TicketEntryController(DatabaseContext context, SessionService session) : ControllerBase
    {
        [HttpGet]
        [HttpGet, Route("ticket/{ticketId}/entry")]
        public async Task<ActionResult<List<TicketEntry>>> GetEntries([FromRoute] Ulid ticketId)
        {
            var ticket = await context.Tickets.FindAsync(ticketId);
            if (ticket is null) return NotFound($"Could not find ticket with id {ticketId}");

            var entries = await context.TicketEntries
                .Where(e => e.TicketId == ticketId)
                .ToListAsync();

            return Ok(entries);
        }

        [HttpGet, Route("ticket/entry/{id}")]
        public async Task<ActionResult<TicketEntry>> GetEntry([FromRoute] Ulid id)
        {
            var entry = await context.TicketEntries.FindAsync(id);
            if (entry is null) return NotFound($"Could not find entry with id {id}");

            return Ok(entry);
        }

        [HttpPost, Route("ticket/entry")]
        public async Task<IActionResult> CreateEntry([FromBody] TicketEntry entry)
        {
            entry.TechnicianId = session.GetUserId();
            entry.EntryDate = DateTime.Now;

            context.Add(entry);
            await context.SaveChangesAsync();

            return Ok(entry);
        }
    }
}