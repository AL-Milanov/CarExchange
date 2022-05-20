using CarExchange.Areas.Admin.Models;
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
            var model = await FillInfo();

            return View(model);
        }

        private async Task<CreateCar> FillInfo()
        {
            var createModel = new CreateCar();

            var bodyTypes = Enum.GetNames(typeof(BodyType));
            var colorTypes = Enum.GetNames(typeof(Color));
            var fuelTypes = Enum.GetNames(typeof(Fuel));
            var manufacturerTypes = Enum.GetNames(typeof(Manufacturer));
            var transmissionTypes = Enum.GetNames(typeof(Transmission));

            createModel.BodyTypes = bodyTypes;
            createModel.Colors = colorTypes;
            createModel.FuelType = fuelTypes;
            createModel.Manufacturers = manufacturerTypes;
            createModel.Transmissions = transmissionTypes;

            var features = await _featureService.GetAll();

            createModel.Features = features;

            return createModel;
        }
    }
}
