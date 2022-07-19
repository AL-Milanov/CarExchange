﻿using CarExchange.Core.Common;
using CarExchange.Core.Models;
using CarExchange.Core.Services.Contracts;
using CarExchange.Infrastructure.Data.Common.ApplicationRepository.Contracts;
using CarExchange.Infrastructure.Data.Enums;
using CarExchange.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CarExchange.Core.Services
{
    public class CarService : ICarService
    {
        private const string errorMessage = "Cannot update entity.";

        private const int _pageResults = 10;

        private readonly IApplicationRepository _repo;

        private readonly IImageService _imageService;

        public CarService(
            IApplicationRepository repo,
            IImageService imageService)
        {
            _repo = repo;
            _imageService = imageService;
        }

        public async Task Add(CreateCar createCar)
        {
            var manufacturerExists = Enum.TryParse(createCar.Manufacturer, out Manufacturer manufacturer);

            var colorExists = Enum.TryParse(createCar.Color, out Color color);

            var transmissionExists = Enum.TryParse(createCar.Transmission, out Transmission transmission);

            var fuelExists = Enum.TryParse(createCar.FuelType, out Fuel fuel);

            var bodyTypeExists = Enum.TryParse(createCar.BodyType, out BodyType bodyStyle);

            if (!manufacturerExists || !colorExists || !transmissionExists || !fuelExists || !bodyTypeExists)
            {
                throw new ArgumentException("Problem occured, try again later.");
            }

            var imagesId = string.Empty;

            try
            {
                imagesId = await _imageService.Create(createCar.Images);

            }
            catch (Exception)
            {
                throw new OperationCanceledException(errorMessage);
            }

            var featuresIds = createCar?.Features?.Select(x => x).ToList();

            var features = await _repo.GetAll<Feature>()
                .Where(f => featuresIds.Contains(f.Id))
                .ToListAsync();

            var car = new Car
            {
                Bodystyle = bodyStyle,
                Color = color,
                Features = features,
                Description = createCar?.Description,
                Engine = createCar?.Engine,
                Fuel = fuel,
                Gears = createCar.Gears,
                HorsePower = createCar.HorsePower,
                ImageId = imagesId,
                Manufacturer = manufacturer,
                Mileage = createCar.Mileage,
                Model = createCar.Model,
                Seats = createCar.Seats,
                Price = createCar.Price,
                Transmission = transmission
            };

            try
            {
                await _repo.AddAsync(car);
                await _repo.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new OperationCanceledException(errorMessage);
            }
        }

        public async Task Delete(string id)
        {
            var car = await _repo.GetAll<Car>()
                .FirstOrDefaultAsync(x => x.Id == id);

            Guard.AgainstNull(car, nameof(car));
            Guard.AgainstNull(car.ImageId, nameof(car.ImageId));

            try
            {
                await _imageService.Remove(car.ImageId);
                _repo.Delete(car);

                await _repo.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new OperationCanceledException(errorMessage);
            }
        }

        public async Task<CarResponse> GetAll(int page)
        {
            var pageCount = Math.Ceiling(await _repo.GetAll<Car>().CountAsync() / (double)_pageResults);

            var cars = await _repo.GetAll<Car>()
                .Where(c => c.IsBooked == false)
                .Skip((page - 1) * _pageResults)
                .Take(_pageResults)
                .ToListAsync();

            var carsVM = new List<AllCarsVM>();

            foreach (var car in cars)
            {
                var image = await _imageService.GetFirst(car.ImageId);

                carsVM.Add(new AllCarsVM
                {
                    Id = car.Id,
                    Car = car.Manufacturer.ToString() + " " + car.Model,
                    Mileage = car.Mileage,
                    Price = car.Price,
                    Picture = image
                });
            }

            var response = new CarResponse
            {
                Cars = carsVM,
                CurrentPage = page,
                Pages = (int)pageCount
            };

            return response;
        }

        public async Task BookCar(string id)
        {
            var car = await _repo.GetAll<Car>()
                .FirstOrDefaultAsync(x => x.Id == id);

            Guard.AgainstNull(car, nameof(car));

            try
            {
                car.IsBooked = true;
                await _repo.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new OperationCanceledException(errorMessage);
            }
        }

        public async Task ShowCar(string id)
        {
            var car = await _repo.GetAll<Car>()
                .FirstOrDefaultAsync(x => x.Id == id);

            Guard.AgainstNull(car, nameof(car));

            try
            {
                car.IsBooked = false;
                await _repo.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new OperationCanceledException(errorMessage);
            }
        }

    }
}
