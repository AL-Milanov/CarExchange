using Microsoft.EntityFrameworkCore;

namespace CarExchange.Infrastructure.Data.Common
{
    public class Repository : IRepository
    {
        protected DbContext Context { get; set; }

        protected DbSet<T> DbSet<T>() where T : class
        {
            return Context.Set<T>();
        }

        public bool Delete<T>(T entity) where T : class
        {

            var entry = DbSet<T>().Remove(entity);

            if (entry != null)
            {
                return true;
            }

            return false;
        }

        public IQueryable<T> GetAll<T>() where T : class
        {
            return DbSet<T>();
        }

        public async Task SaveChangesAsync()
        {
            await Context.SaveChangesAsync();
        }

        public async Task AddAsync<T>(T entity) where T : class
        {
            await DbSet<T>().AddAsync(entity);
        }

        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}
