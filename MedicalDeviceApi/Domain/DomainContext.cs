using MedicalDevice.Domain.Entities;
using MedicalDevice.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace MedicalDevice.Domain
{
    public class DomainContext : DbContext
    {
        public DomainContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Technician> Technicians { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Line> Lines { get; set; }
        public DbSet<LineModel> LineModels { get; set; }
        public DbSet<LineStep> LineSteps { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<DeviceStep> DeviceSteps { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Set up one to many relationships


            // Seed data for Model with entertaining yet relevant medical device names
            modelBuilder.Entity<Model>().HasData(
                new Model { Id = Guid.NewGuid(), Name = "Heartbeat Harmonizer 2020", Size = DeviceSize.LARGE, Description = "A top-notch device for monitoring and harmonizing heart rhythms." },
                new Model { Id = Guid.NewGuid(), Name = "Nano Scanner X", Size = DeviceSize.MICRO, Description = "Microscopic precision in a tiny package, for groundbreaking diagnostics." },
                new Model { Id = Guid.NewGuid(), Name = "Surgical Symphony", Size = DeviceSize.MEDIUM, Description = "The future of automated precision surgery. Operates like a symphony!" },
                new Model { Id = Guid.NewGuid(), Name = "Pulse Pacer Pro", Size = DeviceSize.SMALL, Description = "Compact and efficient, ensuring stable vitals on the go." }
            );

            // Seed Line Ids
            var largeLineId = Guid.NewGuid();
            var mediumLineId = Guid.NewGuid();
            var smallLineId = Guid.NewGuid();
            var microLineId = Guid.NewGuid();

            // Seed Lines
            modelBuilder.Entity<Line>().HasData(
                new Line { Id = largeLineId, DeviceSize = DeviceSize.LARGE, Description = "Large Device Repair and Maintenance Line" },
                new Line { Id = mediumLineId, DeviceSize = DeviceSize.MEDIUM, Description = "Medium Device Diagnostic and Repair Line" },
                new Line { Id = smallLineId, DeviceSize = DeviceSize.SMALL, Description = "Small Device Quick Repair Line" },
                new Line { Id = microLineId, DeviceSize = DeviceSize.MICRO, Description = "Micro Device Precision Repair Line" }
            );

            // Seed LineSteps
            modelBuilder.Entity<LineStep>().HasData(
                // Steps for Large Line
                new LineStep { Id = Guid.NewGuid(), LineId = largeLineId, Description = "Initial Diagnostic Check" },
                new LineStep { Id = Guid.NewGuid(), LineId = largeLineId, Description = "Precision Calibration" },

                // Steps for Medium Line
                new LineStep { Id = Guid.NewGuid(), LineId = mediumLineId, Description = "Component Alignment" },
                new LineStep { Id = Guid.NewGuid(), LineId = mediumLineId, Description = "Microscopic Inspection" },
                new LineStep { Id = Guid.NewGuid(), LineId = mediumLineId, Description = "Functional Testing" },

                // Steps for Small Line
                new LineStep { Id = Guid.NewGuid(), LineId = smallLineId, Description = "Nano Cleaning" },
                new LineStep { Id = Guid.NewGuid(), LineId = smallLineId, Description = "Circuitry Check" },
                new LineStep { Id = Guid.NewGuid(), LineId = smallLineId, Description = "Reassembly" },
                new LineStep { Id = Guid.NewGuid(), LineId = smallLineId, Description = "Final Quality Assurance" },

                // Steps for Micro Line
                new LineStep { Id = Guid.NewGuid(), LineId = microLineId, Description = "Quantum Tuning" },
                new LineStep { Id = Guid.NewGuid(), LineId = microLineId, Description = "Electron Alignment" },
                new LineStep { Id = Guid.NewGuid(), LineId = microLineId, Description = "Microfiber Polishing" },
                new LineStep { Id = Guid.NewGuid(), LineId = microLineId, Description = "Subatomic Stress Testing" }
            );

            // Seed data for Technician
            modelBuilder.Entity<Technician>().HasData(
                new Technician { Id = Guid.NewGuid(), Name = "Max Fixit", Description = "Gadget geek with a love for retro tech." },
                new Technician { Id = Guid.NewGuid(), Name = "Ivy Wrench", Description = "A wizard in electronic repairs, enjoys rebuilding old radios." },
                new Technician { Id = Guid.NewGuid(), Name = "Chip Solder", Description = "Soldering maestro, often found tinkering with microchips." },
                new Technician { Id = Guid.NewGuid(), Name = "Zoe Zap", Description = "Electrical enthusiast, keen on high-voltage experiments." }
            );
        }
    }
}