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



        public async Task<IActionResult> AllOffers()
        {
            var offers = await _carService.GetAll(1);

            return View(offers);
        }
    }
}
