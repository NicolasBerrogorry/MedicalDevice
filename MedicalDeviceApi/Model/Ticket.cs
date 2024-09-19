namespace MedicalDevice.Model
{
    public class Ticket
    {
        public Ulid Id { get; set; }
        public Ulid DeviceId { get; set; }
        public Ulid CreationUserId { get; set; }
        public DateTime CreationDate { get; set; }
        public TicketState State { get; set; }
        public string Description { get; set; }
        public DateTime? LastModificationDate { get; set; }
        public Ulid? LastModificationUserId { get; set; }

        public User CreationUser { get; set; }
        public Device? Device { get; set; }
        public User? LastModificationUser { get; set; }
    }
}