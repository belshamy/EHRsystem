using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EHRsystem.Models.Entities
{
    public class LabResult
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string TestName { get; set; } = string.Empty;

        [Required]
        public string Result { get; set; } = string.Empty;

        public string? ReferenceRange { get; set; }
        public string? Unit { get; set; }
        public DateTime TestDate { get; set; }
        public string Status { get; set; } // Pending, Completed, Abnormal

        // Foreign Key
        [Required]
        public int PatientId { get; set; }

        // Navigation Property
        [ForeignKey("PatientId")]
        public virtual Patient Patient { get; set; } = null!;

        public LabResult()
        {
            TestDate = DateTime.Now;
            Status = "Pending";
        }
    }
}