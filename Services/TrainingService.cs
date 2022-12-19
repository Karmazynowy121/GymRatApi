using GymRatApi.Commands;
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

        public Task<Training> Create(TrainingCreateCommand trainingCreateCommand)
        {
            if (trainingCreateCommand == null)
            {
                throw new ArgumentNullException("CreateTrainingContract is empty");
            }
            var newTraining = new Training();
            newTraining.Description = trainingCreateCommand.Description;
            newTraining.TrainingDate = trainingCreateCommand.TrainingDate;
            newTraining.Interval = trainingCreateCommand.Interval;
            newTraining.TrainingDuration = trainingCreateCommand.TrainingDuration;
            _dbContext.Add(newTraining);
            _dbContext.SaveChanges();
            return Task.FromResult(newTraining);
        }
    }
}
