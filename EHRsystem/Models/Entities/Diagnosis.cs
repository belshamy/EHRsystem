using System.ComponentModel.DataAnnotations;

namespace EHRsystem.Models.Entities
{
    public class Diagnosis
    {
        [Key]
        public int DiagnosisId { get; set; }

        [Required]
        public int RecordId { get; set; }
        public MedicalRecord MedicalRecord { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string Condition { get; set; } = null!;

        [Required]
        public DateTime DiagnosisDate { get; set; }

        [StringLength(500)]
        public string? Notes { get; set; }
    }
}