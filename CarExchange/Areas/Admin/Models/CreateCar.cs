using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarExchange.Areas.Admin.Models
{
    public class CreateCar
    {

        public string BodyType { get; set; }

        public string Color { get; set; }

        public string FuelType { get; set; }

        public string Manufacturer { get; set; }

        public string Transmission { get; set; }

        public byte[] Image { get; set; }

        public ICollection<SelectListItem> Features { get; set; }
    }
}
