using CarExchange.Core.Models;

namespace CarExchange.Core.Services.Contracts
{
    public interface ICarService
    {
        Task<CarResponse> GetAll(int page);
    }
}
