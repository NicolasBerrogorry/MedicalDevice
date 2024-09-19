namespace MedicalDevice.Model
{
    public class TicketEntry
    {
        public Ulid TicketId { get; set; }
        public DateTime EntryDate { get; set; }
        public Ulid TechnicianId { get; set; }
        public Ulid? ToolId { get; set; }
        public Ulid? PhotoId { get; set; }
        public string Description { get; set; }

        public User Technician { get; set; }
        public Tool Tool { get; set; }
    }
}