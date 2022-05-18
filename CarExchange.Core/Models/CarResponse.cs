namespace CarExchange.Core.Models
{
    public class CarResponse
    {
        public List<AllCarsVM> Cars{ get; set; }

        public int CurrentPage { get; set; }

        public int Pages { get; set; }

        public CarResponse()
        {
            Cars = new List<AllCarsVM>();
        }
    }
}
