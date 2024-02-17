namespace MedicalDevice.Domain.Entities
{
    public class LineModel
    {
        public Guid Id { get; set; }
        public Guid ModelId { get; set; }

        public Model Model { get; set; }
    }
}