using CarExchange.Infrastructure.Data.Common.ApplicationRepository.Contracts;

namespace CarExchange.Infrastructure.Data.Common.ApplicationRepository
{
    public class ApplicationRepository : Repository, IApplicationRepository
    {
        public ApplicationRepository(ApplicationDbContext context)
        {
            Context = context;
        }
    }
}
