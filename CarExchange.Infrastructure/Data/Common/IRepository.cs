namespace CarExchange.Infrastructure.Data.Common
{
    public interface IRepository
    {
        IQueryable<T> GetAll<T>() where T : class;

        bool Delete<T>(T entity) where T : class;

        Task AddAsync<T>(T entity) where T : class;

        Task SaveChangesAsync();

        void Dispose();
    }
}
