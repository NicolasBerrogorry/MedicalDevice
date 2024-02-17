namespace MedicalDevice.Domain.Entities
{
    public class TechnicianLineStep
    {
        public Guid TechnicianId { get; set; }
        public Guid LineStepId { get; set; }

        public Technician Technician { get; set; }
        public LineStep LineStep { get; set; }
    }
}