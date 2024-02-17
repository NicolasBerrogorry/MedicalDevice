namespace MedicalDevice.Domain.Entities
{
    public class DeviceStep
    {
        public Guid Id { get; set; }
        public Guid LineStepId { get; set; }
        public string Inspection { get; set; } = string.Empty;
        public string Task { get; set; } = string.Empty;

        public LineStep LineStep { get; set; }
    }
}