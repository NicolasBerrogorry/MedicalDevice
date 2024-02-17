namespace MedicalDevice.Domain.Entities
{
    public class Technician
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public byte[] Photo { get; set; } = [];
        public string Description { get; set; } = string.Empty;
    }
}