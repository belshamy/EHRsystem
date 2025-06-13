using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EHRsystem.Models.Entities;
using EHRsystem.Models.Entities.Users;
using EHRsystem.Models.Base;

namespace EHRsystem.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<EHRsystem.Models.Base.Patient> Patients { get; set; }
        public DbSet<EHRsystem.Models.Base.Doctor> Doctors { get; set; }
        public DbSet<EHRsystem.Models.Base.Admin> Admins { get; set; }
        
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EHRsystem.Models.Base.Patient>().ToTable("Patients");
            modelBuilder.Entity<EHRsystem.Models.Base.Doctor>().ToTable("Doctors");
            modelBuilder.Entity<EHRsystem.Models.Base.Admin>().ToTable("Admins");

            modelBuilder.Entity<Appointment>()
                .HasOne<ApplicationUser>()
                .WithMany()
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Appointment>()
                .HasOne<ApplicationUser>()
                .WithMany()
                .HasForeignKey(a => a.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Prescription>()
                .HasOne<ApplicationUser>()
                .WithMany()
                .HasForeignKey(p => p.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Prescription>()
                .HasOne<ApplicationUser>()
                .WithMany()
                .HasForeignKey(p => p.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MedicalRecord>()
                .HasOne<ApplicationUser>()
                .WithMany()
                .HasForeignKey(m => m.PatientId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}