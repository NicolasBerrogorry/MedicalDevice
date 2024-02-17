using MedicalDevice.Domain.Enums;

namespace MedicalDevice.Domain.Entities
{
    public class Line
    {
        public Guid Id { get; set; }
        public DeviceSize DeviceSize { get; set; }
        public byte[] Photo { get; set; } = [];
        public string Description { get; set; } = string.Empty;

        public List<LineStep> LineSteps { get; set; }
    }
}