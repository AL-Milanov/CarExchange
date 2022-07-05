using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace CarExchange.Areas.Admin.Models
{
    public class CreateCar
    {
        [StringLength(20, MinimumLength = 2)]
        public string? Model { get; set; }

        [Range(1, int.MaxValue)]
        public int Mileage { get; set; }

        [Range(1, 9)]
        public byte Seats { get; set; }

        [Range(1, 6)]
        public byte Gears { get; set; }

        [Range(1, double.MaxValue)]
        public decimal Price { get; set; }

        [StringLength(750)]
        public string? Description { get; set; }

        public string BodyType { get; set; }

        public string Color { get; set; }

        public string FuelType { get; set; }

        public string Manufacturer { get; set; }

        public string Transmission { get; set; }

        public byte[] Image { get; set; }

        public ICollection<string> Features { get; set; }
    }
}
