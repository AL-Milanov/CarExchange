using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarExchange.Core.Services.Contracts
{
    public interface IFeatureService
    {
        Task<IEnumerable<SelectListItem>> GetAll();
    }
}
