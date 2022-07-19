using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarExchange.Core.Models
{
    public class CreateCar
    {
        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string? Model { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Mileage { get; set; }

        [Required]
        [Range(1, 9)]
        public byte Seats { get; set; }

        [Range(1, 6)]
        public byte Gears { get; set; }

        [Range(1, short.MaxValue)]
        public short HorsePower { get; set; }

        [StringLength(20, MinimumLength = 2)]
        public string Engine { get; set; }

        [Required]
        [Range(1, double.MaxValue)]
        public decimal Price { get; set; }

        [StringLength(750)]
        public string? Description { get; set; }

        [Required]
        public string BodyType { get; set; }

        [Required]
        public string Color { get; set; }

        [Required]
        public string FuelType { get; set; }

        [Required]
        public string Manufacturer { get; set; }

        [Required]
        public string Transmission { get; set; }

        public ICollection<string> Images { get; set; }

        public List<string> Features { get; set; }

        public CreateCar()
        {
            Images = new HashSet<string>();
            Features = new List<string>();
        }
    }
}
