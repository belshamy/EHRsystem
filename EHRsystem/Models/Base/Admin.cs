using System.ComponentModel.DataAnnotations;
using EHRsystem.Models.Entities.Users;

namespace EHRsystem.Models.Entities
{
    public class Admin : ApplicationUser
    {
        [StringLength(100)]
        public string? Department { get; set; }
        
        public DateTime? LastLoginDate { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        
        [StringLength(100)]
        public string? AccessLevel { get; set; }
    }
}