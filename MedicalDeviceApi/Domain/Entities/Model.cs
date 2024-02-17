using MedicalDevice.Domain.Enums;

namespace MedicalDevice.Domain.Entities
{
    public class Model
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DeviceSize Size { get; set; }
        public byte[] Photo { get; set; } = [];
        public string Description { get; set; } = string.Empty;
    }
}