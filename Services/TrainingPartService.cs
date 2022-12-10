using GymRatApi.Entieties;

namespace GymRatApi.Services
{
    public class TrainingPartService : BaseServices, ITrainingPartServices
    {
        public TrainingPartService(GymDbContext dbContext)
            : base(dbContext)
        {
        }

        public Task<TrainingPart> Create(int amountSeries, int bodyWeight,int reps,int breakBetweenSeries, int exerciseId, int trainingId)
        {
            if (amountSeries< 0 || bodyWeight < 0 || reps < 0 || exerciseId < 0)
            {
                throw new ArgumentNullException("AmountSeries or BodyWeight is empty");
            }
            var rootTraining = _dbContext.Training.FirstOrDefault(t => t.Id == trainingId);

            if (rootTraining == null)
            {
                throw new Exception($"Training with id: {trainingId} does not exist");
            }
            var rootExercise = _dbContext.Exercises.FirstOrDefault(ex => ex.Id == exerciseId);

            if (rootExercise == null)
            {
                throw new Exception($"Exercise with id: {exerciseId} does not exist");
            }

            var newTrainingPart = new TrainingPart();
            newTrainingPart.AmountSeries = amountSeries;
            newTrainingPart.BodyWeight = bodyWeight;
            newTrainingPart.Reps = reps;
            newTrainingPart.BreakBetweenSeries = breakBetweenSeries;
            newTrainingPart.ExerciseId = exerciseId;
            newTrainingPart.Exercise = rootExercise;
            newTrainingPart.TrainingId = trainingId;
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
