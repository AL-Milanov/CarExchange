using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarExchange.Areas.Admin.Models
{
    public class CreateCar
    {

        public IEnumerable<string> BodyTypes { get; set; }

        public IEnumerable<string> Colors { get; set; }

        public IEnumerable<string> FuelType { get; set; }

        public IEnumerable<string> Manufacturers { get; set; }

        public IEnumerable<string> Transmissions { get; set; }

        public IEnumerable<SelectListItem> Features { get; set; }
    }
}
