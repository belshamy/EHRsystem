using System.ComponentModel.DataAnnotations;
using EHRsystem.Models.Entities.Users;

namespace EHRsystem.Models.Entities
{
    public class Appointment
    {
        public int Id { get; set; }

        [Required]
        public string PatientId { get; set; } = string.Empty;
        public virtual ApplicationUser Patient { get; set; } = null!;

        [Required]
        public string DoctorId { get; set; } = string.Empty;
        public virtual ApplicationUser Doctor { get; set; } = null!;

        [Required]
        public DateTime AppointmentDate { get; set; }

        [Required]
        public AppointmentStatus Status { get; set; } = AppointmentStatus.Pending;

        [StringLength(500)]
        public string? Notes { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
    }
}