namespace MedicalDevice.Domain.Entities
{
    public class Device
    {
        public Guid Id { get; set; }
        public Guid ModelId { get; set; }

        public Model Model { get; set; }
        public List<DeviceStep> DeviceSteps { get; set; }
    }
}