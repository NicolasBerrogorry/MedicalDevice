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
                }
            );


            modelBuilder.Entity<User>()
            .HasData(
                new User
                {
                    Id = Ulid.NewUlid(),
                    PhotoId = aliceSmithPhotoId,
                    Role = UserRole.Cashier,
                    Name = "Alice Smith",
                    Initials = "AS",
                    Description = "Billing"
                },
                new User
                {
                    Id = Ulid.NewUlid(),
                    PhotoId = bobJohnsonPhotoId,
                    Role = UserRole.Technician,
                    Name = "Bob Johnson",
                    Initials = "BJ",
                    Description = "X-Ray Technician"
                },
                new User
                {
                    Id = Ulid.NewUlid(),
                    PhotoId = carolWilliamsPhotoId,
                    Role = UserRole.Cashier,
                    Name = "Carol Williams",
                    Initials = "CW",
                    Description = "Insurance Processing"
                },
                new User
                {
                    Id = Ulid.NewUlid(),
                    PhotoId = davidBrownPhotoId,
                    Role = UserRole.Technician,
                    Name = "David Brown",
                    Initials = "DB",
                    Description = "Laboratory Technician"
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