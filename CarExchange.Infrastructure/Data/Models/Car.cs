using CarExchange.Infrastructure.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace CarExchange.Infrastructure.Data.Models
{
    public class Car
    {
        [Key]
        [StringLength(36)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public Manufacturer Manufacturer { get; set; }

        [Required]
        [StringLength(35)]
        public string? Model { get; set; }

        [Required]
        public Color Color { get; set; }

        [Required]
        public Transmission Transmission { get; set; }

        [Required]
        public Fuel Fuel { get; set; }

        public int Mileage { get; set; }

        [Required]
        public BodyType Bodystyle { get; set; }

        public byte Seats { get; set; }

        public byte Gears { get; set; }

        public string? Engine { get; set; }

        public short HorsePower { get; set; }

        public decimal Price { get; set; }

        [StringLength(325)]
        public string? Description { get; set; }

        [Required]
        public bool IsBooked { get; set; } = false;

        public ICollection<Feature>? Features { get; set; }

        public string? ImageId { get; set; }

        public Car()
        {
            Features = new List<Feature>();
        }
    }
}
