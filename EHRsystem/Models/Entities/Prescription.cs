using System.ComponentModel.DataAnnotations;
using EHRsystem.Models.Entities.Users;

namespace EHRsystem.Models.Entities
{
    public class Prescription
    {
        public int Id { get; set; }

        [Required]
        public string PatientId { get; set; } = string.Empty;
        public virtual ApplicationUser Patient { get; set; } = null!;

        [Required]
        public string DoctorId { get; set; } = string.Empty;
        public virtual ApplicationUser Doctor { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string Medication { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Dosage { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Frequency { get; set; } = string.Empty; // e.g., "Twice daily"

        [Required]
        [StringLength(100)]
        public string Duration { get; set; } = string.Empty; // e.g., "7 days"

        [StringLength(500)]
        public string? Instructions { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
    }
}