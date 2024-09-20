namespace MedicalDevice.Model
{
    public class Device
    {
        public Ulid Id { get; set; }
        public DateTime CreationDate { get; set; }
        public Ulid CreationUserId { get; set; }
        public Ulid? PhotoId { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }

        public User? CreationUser { get; set; }
    }
}