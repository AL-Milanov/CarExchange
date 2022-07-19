using CarExchange.Core.Models;
using CarExchange.Core.Services.Contracts;
using CarExchange.Infrastructure.Data.Enums;
using Microsoft.AspNetCore.Mvc;

namespace CarExchange.Areas.Admin.Controllers
{
    public class CarController : BaseController
    {
        private readonly ICarService _carService;
        private readonly IFeatureService _featureService;

        public CarController(
            ICarService carService,
            IFeatureService featureService)
        {
            _carService = carService;
            _featureService = featureService;

        }

        public async Task<IActionResult> Create()
        {

            ViewBag.BodyTypes = Enum.GetNames(typeof(BodyType));
            ViewBag.Colors = Enum.GetNames(typeof(Color));
            ViewBag.FuelTypes = Enum.GetNames(typeof(Fuel));
            ViewBag.Manufacturers = Enum.GetNames(typeof(Manufacturer));
            ViewBag.Transmissions = Enum.GetNames(typeof(Transmission));

            ViewBag.Features = await _featureService.GetAll();

            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateCar car)
        {
            var featuresString = string.Join(",", car.Features);

            car.Features = new List<string>()
            {
                featuresString
            };

            return RedirectToAction(nameof(AddImages), car);
        }

        public IActionResult AddImages(CreateCar car)
        {
            
            return View(car);
        }

        [HttpPost]
        public async Task<IActionResult> AddImages(CreateCar car, ICollection<IFormFile> formFiles)
        {
            foreach (var image in formFiles)
            {
                if (image.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        await image.CopyToAsync(ms);
                        var filebytes = ms.ToArray();
                        string imageBytes = Convert.ToBase64String(filebytes);

                        car.Images.Add(imageBytes);
                    }
                }
            }

            var features = car.Features[0].Split(",").ToList();

            car.Features = features;

            await SaveOffer(car);

            return RedirectToAction("Home");
        }

        private async Task SaveOffer(CreateCar model)
        {
            await _carService.Add(model);
        }
    }
}
