using System;
using System.ComponentModel.DataAnnotations;

namespace EHRsystem.Models.Entities
{
    public class DoctorSchedule
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public int DoctorId { get; set; }
        
        [Required]
        public DayOfWeek DayOfWeek { get; set; }
        
        [Required]
        public TimeSpan StartTime { get; set; }
        
        [Required]
        public TimeSpan EndTime { get; set; }
        
        public bool IsAvailable { get; set; } = true;
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        
        // Navigation property
        public virtual Doctor Doctor { get; set; } = null!;
    }
}