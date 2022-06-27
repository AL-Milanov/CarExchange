using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarExchange.Areas.Admin.Models
{
    public class CreateCar
    {
        public string? Model { get; set; }

        public int Mileage { get; set; }

        public byte Seats { get; set; }

        public byte Gears { get; set; }

        public decimal Price { get; set; }

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
