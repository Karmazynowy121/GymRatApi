using GymRatApi.ContractModules;
using GymRatApi.Entieties;

namespace GymRatApi.Services
{
    public class TrainingPartService : BaseServices, ITrainingPartServices
    {
        public TrainingPartService(GymDbContext dbContext)
            : base(dbContext)
        {
        }

        public Task<TrainingPart> Create(CreateTrainingPartContract createTrainingPartContract)
        {
            if (createTrainingPartContract == null)
            {
                throw new ArgumentNullException("CreateTrainingPartContract is empty");
            }
            var rootTraining = _dbContext.Training.FirstOrDefault(t => t.Id == createTrainingPartContract.TrainingId);

            if (rootTraining == null)
            {
                throw new Exception($"Training with id: {createTrainingPartContract.TrainingId} does not exist");
            }
            var rootExercise = _dbContext.Exercises.FirstOrDefault(ex => ex.Id == createTrainingPartContract.ExerciseId);

            if (rootExercise == null)
            {
                throw new Exception($"Exercise with id: {createTrainingPartContract.ExerciseId} does not exist");
            }

            var newTrainingPart = new TrainingPart();
            newTrainingPart.AmountSeries = createTrainingPartContract.AmountSeries;
            newTrainingPart.BodyWeight = createTrainingPartContract.BodyWeight;
            newTrainingPart.Reps = createTrainingPartContract.Reps;
            newTrainingPart.BreakBetweenSeries = createTrainingPartContract.BreakBetweenSeries;
            newTrainingPart.ExerciseId = createTrainingPartContract.ExerciseId;
            newTrainingPart.Exercise = rootExercise;
            newTrainingPart.TrainingId = createTrainingPartContract.TrainingId;
            newTrainingPart.Training = rootTraining;
            _dbContext.Add(newTrainingPart);
            _dbContext.SaveChanges();
            return Task.FromResult(newTrainingPart);
        }
        public Task<List<TrainingPart>> GetAll() => Task.FromResult(_dbContext.TrainingParts.ToList());
        public Task Delete(int id)
        {
            var trainingPart = _dbContext
                .TrainingParts
                .FirstOrDefault(t => t.Id == id);
            if (trainingPart == null)
                throw new Exception("trainingPart not found");
            _dbContext.TrainingParts.Remove(trainingPart);
            _dbContext.SaveChanges();
            return Task.CompletedTask;
        }
        public Task Update(TrainingPart trainingPart)
        {
            _dbContext.Update(trainingPart);
            _dbContext.SaveChanges();
            return Task.CompletedTask;

        }
    }
}
