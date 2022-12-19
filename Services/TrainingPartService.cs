using AutoMapper;
using GymRatApi.Commands.TrainingPartCommands;
using GymRatApi.Dto;
using GymRatApi.Entieties;

namespace GymRatApi.Services
{
    public class TrainingPartService : BaseServices, ITrainingPartServices
    {
        private readonly IMapper _mapper;
        public TrainingPartService(GymDbContext dbContext, IMapper mapper)
            : base(dbContext)
        {
            _mapper = mapper;
        }

        public Task<TrainingPartDto> Create(TrainingPartCreateCommand trainingPartCreateCommand)
        {
            if (trainingPartCreateCommand == null)
            {
                throw new ArgumentNullException("CreateTrainingPartContract is empty");
            }
            var rootTraining = _dbContext.Training.FirstOrDefault(t => t.Id == trainingPartCreateCommand.TrainingId);

            if (rootTraining == null)
            {
                throw new Exception($"Training with id: {trainingPartCreateCommand.TrainingId} does not exist");
            }
            var rootExercise = _dbContext.Exercises.FirstOrDefault(ex => ex.Id == trainingPartCreateCommand.ExerciseId);

            if (rootExercise == null)
            {
                throw new Exception($"Exercise with id: {trainingPartCreateCommand.ExerciseId} does not exist");
            }

            var newTrainingPart = new TrainingPart();
            newTrainingPart.AmountSeries = trainingPartCreateCommand.AmountSeries;
            newTrainingPart.BodyWeight = trainingPartCreateCommand.BodyWeight;
            newTrainingPart.Reps = trainingPartCreateCommand.Reps;
            newTrainingPart.BreakBetweenSeries = trainingPartCreateCommand.BreakBetweenSeries;
            newTrainingPart.ExerciseId = trainingPartCreateCommand.ExerciseId;
            newTrainingPart.Exercise = rootExercise;
            newTrainingPart.TrainingId = trainingPartCreateCommand.TrainingId;
            newTrainingPart.Training = rootTraining;
            _dbContext.Add(newTrainingPart);
            _dbContext.SaveChanges();
            return Task.FromResult(_mapper.Map<TrainingPartDto>(newTrainingPart));
        }
        public Task<List<TrainingPartDto>> GetAll() 
            => Task.FromResult(_mapper.Map <List<TrainingPartDto>> (_dbContext.TrainingParts.ToList()));
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
        public Task Update(TrainingPartUpdateCommand trainingPartUpdateCommand)
        {
            _dbContext.Update(trainingPartUpdateCommand);
            _dbContext.SaveChanges();
            return Task.CompletedTask;

        }
    }
}
