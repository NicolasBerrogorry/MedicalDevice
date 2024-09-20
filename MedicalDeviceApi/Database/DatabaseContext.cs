using MedicalDevice.Model;
using Microsoft.EntityFrameworkCore;

namespace MedicalDevice.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketEntry> TicketEntries { get; set; }
        public DbSet<Tool> Tools { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Blob> Blobs { get; set; }

        public DatabaseContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TicketEntry>(eb => eb.HasKey(e => new { e.TicketId, e.EntryDate }));

            var aliceSmithPhotoId = Ulid.NewUlid();
            var bobJohnsonPhotoId = Ulid.NewUlid();
            var carolWilliamsPhotoId = Ulid.NewUlid();
            var davidBrownPhotoId = Ulid.NewUlid();

            var bpMonitorX100PhotoId = Ulid.NewUlid();
            var glucoseMonitorAdvancePhotoId = Ulid.NewUlid();
            var respiratoryMonitorLitePhotoId = Ulid.NewUlid();
            var ultrasoundPortableProPhotoId = Ulid.NewUlid();

            modelBuilder.Entity<Blob>()
            .HasData(
                new Blob()
                {
                    Id = aliceSmithPhotoId,
                    Content = GetBytesFromDisk("Mocks/Alice Smith.webp"),
                    ContentType = "image/webp",
                    CreationTime = DateTime.Now,
                    CreationUser = null,
                    CreationUserId = Ulid.Empty
                },
                new Blob()
                {
                    Id = bobJohnsonPhotoId,
                    Content = GetBytesFromDisk("Mocks/Bob Johnson.webp"),
                    ContentType = "image/webp",
                    CreationTime = DateTime.Now,
                    CreationUser = null,
                    CreationUserId = Ulid.Empty
                },
                new Blob()
                {
                    Id = carolWilliamsPhotoId,
                    Content = GetBytesFromDisk("Mocks/Carol Williams.webp"),
                    ContentType = "image/webp",
                    CreationTime = DateTime.Now,
                    CreationUser = null,
                    CreationUserId = Ulid.Empty
                },
                new Blob()
                {
                    Id = davidBrownPhotoId,
                    Content = GetBytesFromDisk("Mocks/David Brown.webp"),
                    ContentType = "image/webp",
                    CreationTime = DateTime.Now,
                    CreationUser = null,
                    CreationUserId = Ulid.Empty
                },
                new Blob()
                {
                    Id = bpMonitorX100PhotoId,
                    Content = GetBytesFromDisk("Mocks/BP Monitor X100.webp"),
                    ContentType = "image/webp",
                    CreationTime = DateTime.Now,
                    CreationUser = null,
                    CreationUserId = Ulid.Empty
                },
                new Blob()
                {
                    Id = glucoseMonitorAdvancePhotoId,
                    Content = GetBytesFromDisk("Mocks/Glucose Monitor Advance.webp"),
                    ContentType = "image/webp",
                    CreationTime = DateTime.Now,
                    CreationUser = null,
                    CreationUserId = Ulid.Empty
                },
                new Blob()
                {
                    Id = ultrasoundPortableProPhotoId,
                    Content = GetBytesFromDisk("Mocks/Ultrasound Portable PRO.webp"),
                    ContentType = "image/webp",
                    CreationTime = DateTime.Now,
                    CreationUser = null,
                    CreationUserId = Ulid.Empty
                },
                new Blob()
                {
                    Id = respiratoryMonitorLitePhotoId,
                    Content = GetBytesFromDisk("Mocks/Respiratory Monitor Lite.webp"),
                    ContentType = "image/webp",
                    CreationTime = DateTime.Now,
                    CreationUser = null,
                    CreationUserId = Ulid.Empty
                }
            );

            var aliceSmithId = Ulid.NewUlid();
            var bobJohnsonId = Ulid.NewUlid();
            var carolWilliamsId = Ulid.NewUlid();
            var davidBrownId = Ulid.NewUlid();

            modelBuilder.Entity<User>()
            .HasData(
                new User
                {
                    Id = aliceSmithId,
                    PhotoId = aliceSmithPhotoId,
                    Role = UserRole.Cashier,
                    Name = "Alice Smith",
                    Initials = "AS",
                    Description = "Billing"
                },
                new User
                {
                    Id = bobJohnsonId,
                    PhotoId = bobJohnsonPhotoId,
                    Role = UserRole.Technician,
                    Name = "Bob Johnson",
                    Initials = "BJ",
                    Description = "X-Ray Technician"
                },
                new User
                {
                    Id = carolWilliamsId,
                    PhotoId = carolWilliamsPhotoId,
                    Role = UserRole.Cashier,
                    Name = "Carol Williams",
                    Initials = "CW",
                    Description = "Insurance Processing"
                },
                new User
                {
                    Id = davidBrownId,
                    PhotoId = davidBrownPhotoId,
                    Role = UserRole.Technician,
                    Name = "David Brown",
                    Initials = "DB",
                    Description = "Laboratory Technician"
                }
            );

            modelBuilder.Entity<Device>().HasData(
                new Device
                {
                    Id = Ulid.NewUlid(),
                    CreationDate = DateTime.Now,
                    CreationUserId = aliceSmithId,
                    PhotoId = bpMonitorX100PhotoId,
                    Model = "BP Monitor X100",
                    SerialNumber = "BP-001-X100"
                },
                new Device
                {
                    Id = Ulid.NewUlid(),
                    CreationDate = DateTime.Now,
                    CreationUserId = bobJohnsonId,
                    PhotoId = glucoseMonitorAdvancePhotoId,
                    Model = "Glucose Monitor Advance",
                    SerialNumber = "GL-002-ADV"
                },
                new Device
                {
                    Id = Ulid.NewUlid(),
                    CreationDate = DateTime.Now,
                    CreationUserId = carolWilliamsId,
                    PhotoId = ultrasoundPortableProPhotoId,
                    Model = "Ultrasound Portable PRO",
                    SerialNumber = "US-003-PRO"
                },
                new Device
                {
                    Id = Ulid.NewUlid(),
                    CreationDate = DateTime.Now,
                    CreationUserId = davidBrownId,
                    PhotoId = respiratoryMonitorLitePhotoId,
                    Model = "Respiratory Monitor Lite",
                    SerialNumber = "RM-004-LITE"
                }
            );
        }

        private static byte[] GetBytesFromDisk(string fileName)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), fileName);
            if (!File.Exists(filePath)) throw new InvalidOperationException($"The file {filePath} was not found.");
            return File.ReadAllBytes(filePath);
        }
    }
}