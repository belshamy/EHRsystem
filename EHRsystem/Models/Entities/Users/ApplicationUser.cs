using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace EHRsystem.Models.Entities.Users
{
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(200)]
        public string? FirstName { get; set; }
        
        [MaxLength(100)]
        public string? LastName { get; set; }
        
        public string? Address { get; set; }
        
        public DateTime? DateCreated { get; set; } = DateTime.UtcNow;
        
        public bool IsActive { get; set; } = true;
    }
}