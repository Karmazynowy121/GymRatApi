using GymRatApi.ContractModules;
using GymRatApi.Entieties;
using GymRatApi.Utilis;

namespace GymRatApi.Services
{
    public class TrainingService : BaseServices, ITrainingService
    {
        public TrainingService(GymDbContext dbContext) 
            : base(dbContext)
        {
        }

        public Task<Training> Create(CreateTrainingContract createTrainingContract)
        {
            if (createTrainingContract == null)
            {
                throw new ArgumentNullException("CreateTrainingContract is empty");
            }
            var newTraining = new Training();
            newTraining.Description = createTrainingContract.Description;
            newTraining.TrainingDate = createTrainingContract.TrainingDate;
            newTraining.Interval = createTrainingContract.Interval;
            newTraining.TrainingDuration = createTrainingContract.TrainingDuration;
            _dbContext.Add(newTraining);
            _dbContext.SaveChanges();
            return Task.FromResult(newTraining);
        }
    }
}
