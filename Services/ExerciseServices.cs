using GymRatApi.Commands;
using GymRatApi.Dto;
using GymRatApi.Entieties;
using Microsoft.EntityFrameworkCore;

namespace GymRatApi.Services
{
    public class ExerciseServices : BaseServices ,IExerciseServices
    {
        public ExerciseServices(GymDbContext dbContext) 
            : base(dbContext)
        {
        }

        public Task<Exercise> Create(ExerciseCreateCommand exerciseCreateCommand)
        {
            if (exerciseCreateCommand == null)
            {
                throw new ArgumentNullException("CreateExerciseContract is null");
            }
            var newExercise = new Exercise();
            newExercise.Description = exerciseCreateCommand.Description;
            newExercise.Name = exerciseCreateCommand.Name;
            _dbContext.Add(newExercise);
            _dbContext.SaveChanges();
            return Task.FromResult(newExercise);
        }
        public Task<List<Exercise>> GetAll()
            => Task.FromResult(_dbContext.Exercises.Include(e => e.Video).ToList());

        public Task<Exercise> GetbyName(ExerciseGetDto exerciseGetDto)
        {
            

            var exercise = _dbContext.Exercises.FirstOrDefault(g => g.Name == exerciseGetDto.Name);
            if (exercise == null)
            {
                throw new Exception($"Exercise {exerciseGetDto} does not exist");
            }
            return Task.FromResult(exercise);
        }
        public Task Delete (ExerciseDeleteCommand exerciseDeleteCommand)
        {
            var exercise = _dbContext
                .Exercises
                .FirstOrDefault(g => g.Id == exerciseDeleteCommand.Id);
            if (exercise == null)
                throw new Exception("Exercise not found");
            _dbContext.Exercises.Remove(exercise);
            _dbContext.SaveChanges();
            return Task.CompletedTask;
        }
        
    }
}
