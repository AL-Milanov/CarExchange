using CarExchange.Core.Models;

namespace CarExchange.Core.Services.Contracts
{
    public interface IImageService
    {
        Task<string> Create(ICollection<string> images);

        Task<ImageVM> Get(string id);

        Task Remove(string id);

        Task<string> GetFirst(string id);
    }
}
