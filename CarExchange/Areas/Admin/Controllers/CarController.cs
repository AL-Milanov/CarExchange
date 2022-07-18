﻿
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

        private CreateCar createCar;

        public CarController(
            ICarService carService,
            IFeatureService featureService)
        {
            _carService = carService;
            _featureService = featureService;

            createCar = new();
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

            return RedirectToAction(nameof(AddFeatures), car);
        }

        public async Task<IActionResult> AddFeatures(CreateCar car)
        {
            ViewBag.Features = await _featureService.GetAll();

            return View(nameof(AddFeatures), car);
        }

        [HttpPost]
        public IActionResult AddFeatures(CreateCar car, string[] features)
        {
            foreach (var feature in features)
            {
                car.Features.Add(feature);
            }

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

            await SaveOffer(car);

            return RedirectToAction(nameof(Index), "Home");
        }

        private async Task SaveOffer(CreateCar model)
        {
            await _carService.Add(model);
        }
    }
}
