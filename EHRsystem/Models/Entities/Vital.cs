using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EHRsystem.Models.Entities
{
    public class Vital
    {
        [Key]
        public int Id { get; set; }

        public double? Temperature { get; set; }
        public int? BloodPressureSystolic { get; set; }
        public int? BloodPressureDiastolic { get; set; }
        public int? HeartRate { get; set; }
        public int? RespiratoryRate { get; set; }
        public double? Weight { get; set; }
        public double? Height { get; set; }
        public DateTime RecordedDate { get; set; }

        // Foreign Key
        [Required]
        public int PatientId { get; set; }

        // Navigation Property
        [ForeignKey("PatientId")]
        public virtual Patient Patient { get; set; } =null!;

        public Vital()
        {
            RecordedDate = DateTime.Now;
        }
    }
}



namespace EHRsystem.Models.Entities
{
    public class Review
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }

        public string? Comment { get; set; }
        public DateTime ReviewDate { get; set; }
        public string ReviewType { get; set; } = string.Empty; // Hospital, Service, etc.

        // Foreign Key
        [Required]
        public int PatientId { get; set; }

        // Navigation Property
        [ForeignKey("PatientId")]
        public virtual Patient Patient { get; set; } = null!;

        public Review()
        {
            ReviewDate = DateTime.Now;
        }
    }
}