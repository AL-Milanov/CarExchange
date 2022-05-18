using CarExchange.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionCoreExtensions
    {
        public static IServiceCollection AddDbContexts(
            this IServiceCollection service,
            IConfiguration config)
        {
            var npgsqlConnectionString = config["ConnectionStrings:Npg"];

            service.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(npgsqlConnectionString));
            service.AddDatabaseDeveloperPageExceptionFilter();

            return service;
        }
    }
}
