namespace MedicalDevice.Model
{
    public class User
    {
        public Ulid Id { get; set; }
        public Ulid PhotoId { get; set; }
        public UserRole Role { get; set; }
        public string Name { get; set; }
        public string Initials { get; set; }
        public string Description { get; set; }
    }
}