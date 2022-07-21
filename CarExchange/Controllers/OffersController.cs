using CarExchange.Core.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CarExchange.Controllers
{
    public class OffersController : Controller
    {
        private readonly ICarService _carService;
        private readonly IFeatureService _featureService;

        public OffersController(ICarService carService,
            IFeatureService featureService)
        {
            _carService = carService;
            _featureService = featureService;
        }

        public async Task<IActionResult> AllOffers(int page = 1)
        {
            var offers = await _carService.GetAll(page);

            return View(offers);
        }

        public async Task<IActionResult> Product(string id)
        {
            var car = await _carService.GetById(id);

            return View();
        }
    }
}
