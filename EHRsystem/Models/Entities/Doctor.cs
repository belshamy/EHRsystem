using System.ComponentModel.DataAnnotations;
using EHRsystem.Models.Entities.Users;

namespace EHRsystem.Models.Entities
{
    public class Doctor : ApplicationUser
    {
        public string? LicenseNumber { get; set; }
        public string? Specialization { get; set; }
        public string? Department { get; set; }
        public int YearsOfExperience { get; set; }
        public string? Education { get; set; }
        public string? Certifications { get; set; }
        public decimal ConsultationFee { get; set; }
        public bool IsAvailable { get; set; } = true;
        
        // Navigation properties
        public virtual ICollection<Appointment>? Appointments { get; set; }
        public virtual ICollection<MedicalFile>? MedicalFiles { get; set; }
        public virtual ICollection<DoctorReview>? Reviews { get; set; }
        public virtual ICollection<DoctorSchedule>? Schedules { get; set; }
    }
}