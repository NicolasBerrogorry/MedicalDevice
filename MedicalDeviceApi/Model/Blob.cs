namespace MedicalDevice.Model
{
    public class Blob
    {
        public Ulid Id { get; set; }
        public Ulid? CreationUserId { get; set; }
        public DateTime CreationTime { get; set; }
        public string ContentType { get; set; }
        public byte[] Content { get; set; }

        public User? CreationUser { get; set; }
    }
}