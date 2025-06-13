using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace EHRsystem.Models.Entities
{
    public class Medication
    {
        [Key]
        public int MedicationId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;

        [StringLength(500)]
        public string? Description { get; set; }

        public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
    }
}