// Models/Entities/BaseEntity.cs
namespace EHRsystem.Models.Entities
{
    public class BaseEntity
    {
        public string? Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}