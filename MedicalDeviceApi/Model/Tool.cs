namespace MedicalDevice.Model
{
    public class Tool
    {
        public Ulid Id { get; set; }
        public Ulid PhotoId { get; set; }

        public string Name { get; set; }
        public string Model { get; set; }
    }
}