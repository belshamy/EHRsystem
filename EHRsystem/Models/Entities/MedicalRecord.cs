using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EHRsystem.Models.Entities.Users;

namespace EHRsystem.Models.Entities
{
    public class MedicalRecord
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PatientId { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(2000)]
        public string Description { get; set; } = string.Empty;

        [StringLength(100)]
        public string? Diagnosis { get; set; }

        [StringLength(100)]
        public string? Treatment { get; set; }

        [Required]
        public DateTime RecordDate { get; set; } = DateTime.Now;

        [StringLength(100)]
        public string? RecordedBy { get; set; }

        [StringLength(1000)]
        public string? Notes { get; set; }

        // Navigation properties
        [ForeignKey("PatientId")]
        public virtual ApplicationUser Patient { get; set; } = null!;
    }
}