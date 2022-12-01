using GymRatApi.Entieties;

namespace GymRatApi.Services
{
    public class BaseServices
    {
        protected readonly GymDbContext _dbContext;
        public BaseServices(GymDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
