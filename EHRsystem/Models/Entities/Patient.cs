using System.ComponentModel.DataAnnotations;
using EHRsystem.Models.Entities.Users;

namespace EHRsystem.Models.Entities
{
    public class Patient : ApplicationUser
    {
        public string? MedicalRecordNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public string? BloodType { get; set; }
        public string? Allergies { get; set; }
        public string? EmergencyContactName { get; set; }
        public string? EmergencyContactPhone { get; set; }
        public string? InsuranceProvider { get; set; }
        public string? InsuranceNumber { get; set; }
        
        // Navigation properties
        public virtual ICollection<Appointment>? Appointments { get; set; }
        public virtual ICollection<MedicalFile>? MedicalFiles { get; set; }
        public virtual ICollection<LabResult>? LabResults { get; set; }
        public virtual ICollection<Vital>? Vitals { get; set; }
        public virtual ICollection<DoctorReview>? Reviews { get; set; }
    }
}