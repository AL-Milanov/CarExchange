using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace CarExchange.Core.Models
{
    public class AddCar
    {
        
        [Required]
        public string Manufacturer { get; set; }

        [Required]
        [StringLength(35)]
        public string Model { get; set; }

        [Required]
        public string Color { get; set; }

        [Required]
        public string Transmission { get; set; }

        [Required]
        public string Fuel { get; set; }

        public int Mileage { get; set; }

        [Required]
        public string Bodystyle { get; set; }

        public byte Seats { get; set; }

        public byte Gears { get; set; }

        public string? Engine { get; set; }

        public short HorsePower { get; set; }

        public decimal Price { get; set; }

        [StringLength(325)]
        public string? Description { get; set; }

        [Required]
        public bool IsBooked { get; set; } = false;

        public ICollection<SelectListItem>? Features { get; set; }

        public ICollection<byte[]> Images { get; set; }

        public AddCar()
        {
            Features = new List<SelectListItem>();
            Images = new List<byte[]>();
        }
    }
}
