using CarExchange.Core.Services.Contracts;
using CarExchange.Infrastructure.Data.Common.ApplicationRepository.Contracts;
using CarExchange.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CarExchange.Core.Services
{
    public class FeatureService : IFeatureService
    {
        private readonly IApplicationRepository _repo;

        public FeatureService(IApplicationRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<SelectListItem>> GetAll()
        {
            var features = await _repo.GetAll<Feature>()
                .Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id
                })
                .ToListAsync();

            return features;
        }
    }
}
