using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using EHRsystem.Models.Entities;
using EHRsystem.Models.Entities.Users;

namespace EHRsystem.Models.Base
{
    public class Patient : ApplicationUser
    {
        public DateTime? DateOfBirth { get; set; }
        
        [StringLength(10)]
        public string? Gender { get; set; }
        
        [StringLength(50)]
        public string? BloodType { get; set; }
        
        [StringLength(500)]
        public string? MedicalHistory { get; set; }
        
        [StringLength(500)]
        public string? Allergies { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
        public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
        public virtual ICollection<MedicalRecord> MedicalRecords { get; set; } = new List<MedicalRecord>();
    }

    public class Doctor : ApplicationUser
    {
        [Required]
        [StringLength(100)]
        public string Specialization { get; set; } = string.Empty;
        
        [StringLength(50)]
        public string? LicenseNumber { get; set; }
        
        public int YearsOfExperience { get; set; }
        
        [StringLength(500)]
        public string? Qualifications { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
        public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
    }

    public class Admin : ApplicationUser
    {
        [StringLength(100)]
        public string? Department { get; set; }
        
        public DateTime? LastLoginDate { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
    }
}