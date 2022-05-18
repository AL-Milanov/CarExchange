using CarExchange.Core.Models;

namespace CarExchange.Core.Services.Contracts
{
    public interface IImageService
    {
        Task<string> Create(ImageVM model);

        Task<ImageVM> Get(string id);

        Task Remove(string id);
    }
}
