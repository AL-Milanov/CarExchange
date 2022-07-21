namespace CarExchange.Core.Models
{
    public class CarVM
    {
        public string Manufacturer { get; set; }

        public string? Model { get; set; }

        public string Color { get; set; }

        public string Transmission { get; set; }

        public string Fuel { get; set; }

        public int Mileage { get; set; }

        public string Bodystyle { get; set; }

        public byte Seats { get; set; }

        public byte Gears { get; set; }

        public string? Engine { get; set; }

        public short HorsePower { get; set; }

        public decimal Price { get; set; }

        public string? Description { get; set; }

        public ICollection<string>? Features { get; set; }

        public ICollection<string> Images { get; set; }
    }
}
