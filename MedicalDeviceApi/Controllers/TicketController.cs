using MedicalDevice.Database;
using MedicalDevice.Model;
using MedicalDevice.Services;
using Microsoft.AspNetCore.Mvc;

namespace MedicalDevice.Controllers
{
    [ApiController]
    [Route("ticket")]
    public class TicketController(DatabaseContext context, SessionService session) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<Ticket>> CreateTicket([FromBody] Ticket ticket)
        {
            ticket.Id = Ulid.NewUlid();
            ticket.CreationDate = DateTime.Now;
            ticket.State = TicketState.Created;

            context.Add(ticket);
            await context.SaveChangesAsync();

            return Ok(ticket);
        }

        [HttpGet, Route("{id}")]
        public async Task<ActionResult<Ticket>> GetTicket([FromRoute] Ulid id)
        {
            var ticket = await context.Tickets.FindAsync(id);
            if (ticket is null) return NotFound($"Could not find ticket with id {id}");
            return Ok(ticket);
        }

        [HttpPatch, Route("{id}/open")]
        public async Task<ActionResult<Ticket>> OpenTicket([FromRoute] Ulid id)
        {
            var ticket = await context.Tickets.FindAsync(id);
            if (ticket is null) return NotFound($"Could not find ticket with id {id}");
            if (ticket.State != TicketState.Created) return BadRequest($"Can not open a ticket with state '{ticket.State}'");

            ticket.LastModificationUserId = session.GetUserId();
            ticket.LastModificationDate = DateTime.Now;
            ticket.State = TicketState.Open;

            await context.SaveChangesAsync();

            return Ok(ticket);
        }

        [HttpPatch, Route("{id}/close")]
        public async Task<ActionResult<Ticket>> CloseTicket([FromRoute] Ulid id)
        {
            var ticket = await context.Tickets.FindAsync(id);
            if (ticket is null) return NotFound($"Could not find ticket with id {id}");
            if (ticket.State != TicketState.Open) return BadRequest($"Can not close a ticket with state '{ticket.State}'");

            ticket.LastModificationUserId = session.GetUserId();
            ticket.LastModificationDate = DateTime.Now;
            ticket.State = TicketState.Closed;

            await context.SaveChangesAsync();

            return Ok(ticket);
        }
    }
}