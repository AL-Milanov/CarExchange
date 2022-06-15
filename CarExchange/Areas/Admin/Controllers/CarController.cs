using CarExchange.Areas.Admin.Models;
using CarExchange.Core.Models;
using CarExchange.Core.Services.Contracts;
using CarExchange.Infrastructure.Data.Enums;
using Microsoft.AspNetCore.Http;
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
        public async Task<IActionResult> Create(
            CreateCar model)
        {
            
            var x = model.Features;

            await _carService.Add(null);


            return RedirectToAction("/");
        }

    }
}
