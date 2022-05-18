namespace CarExchange.Core.Models
{
    public class AllCarsVM
    {
        public string Id { get; set; }

        public string Car { get; set; }

        public decimal Price { get; set; }

        public int Mileage { get; set; }

        public byte[]? Picture { get; set; }
    }
}
