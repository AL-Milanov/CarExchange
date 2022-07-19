using CarExchange.Core.Models;

namespace CarExchange.Core.Services.Contracts
{
    public interface ICarService
    {
        Task<CarResponse> GetAll(int page);

        Task Add(CreateCar car);

        Task Delete(string id);

        Task BookCar(string id);

        Task ShowCar(string id);
    }
}
