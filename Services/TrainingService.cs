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

        public Task<Training> Create(List<CreateTrainingPartContract> trainingPart, string description, DateTime trainingDate, int interval)
        {
            if (trainingPart == null)
            {
                throw new ArgumentNullException("trainingPart is empty");
            }
            var newTraining = new Training();
            newTraining.Description = description;
            newTraining.TrainingDate = trainingDate;
            newTraining.Interval = interval;
            _dbContext.Add(newTraining);
            _dbContext.SaveChanges();
            newTraining.TrainingParts = trainingPart.ToTrainigPartList(newTraining.Id);
            _dbContext.Update(newTraining);
            return Task.FromResult(newTraining);

        }
    }
}
