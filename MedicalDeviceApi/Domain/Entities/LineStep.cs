namespace MedicalDevice.Domain.Entities
{
    public class LineStep
    {
        public Guid Id { get; set; }
        public Guid LineId { get; set; }
        public string Description { get; set; } = string.Empty;

        public Line Line { get; set; }
    }
}