using System.ComponentModel.DataAnnotations;

namespace CarExchange.Infrastructure.Data.Models
{
    public class Feature
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public string? Name { get; set; }
    }
}