using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EHRsystem.Models.Entities
{
    public class DoctorReview
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }

        public string? Comment { get; set; }
        public DateTime ReviewDate { get; set; }

        // Foreign Keys
        [Required]
        public int DoctorId { get; set; }
        
        [Required]
        public int PatientId { get; set; }

        // Navigation Properties
        [ForeignKey("DoctorId")]
        public virtual Doctor Doctor { get; set; } = null!;
        
        [ForeignKey("PatientId")]
        public virtual Patient Patient { get; set; }=   null!;

        public DoctorReview()
        {
            ReviewDate = DateTime.Now;
        }
    }
}
