using GymRatApi.ContractModules;
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

        public Task<Exercise> Create(CreateExerciseContract createExerciseContract)
        {
            if (createExerciseContract == null)
            {
                throw new ArgumentNullException("CreateExerciseContract is null");
            }
            var newExercise = new Exercise();
            newExercise.Description = createExerciseContract.Description;
            newExercise.Name = createExerciseContract.Name;
            _dbContext.Add(newExercise);
            _dbContext.SaveChanges();
            return Task.FromResult(newExercise);
        }
        public Task<List<Exercise>> GetAll()
            => Task.FromResult(_dbContext.Exercises.Include(e => e.Video).ToList());

        public Task<Exercise> GetbyName(string name)
        {
            

            var exercise = _dbContext.Exercises.FirstOrDefault(g => g.Name == name);
            if (exercise == null)
            {
                throw new Exception($"Exercise {name} does not exist");
            }
            return Task.FromResult(exercise);
        }
        public Task Delete (int id)
        {
            var exercise = _dbContext
                .Exercises
                .FirstOrDefault(g => g.Id == id);
            if (exercise == null)
                throw new Exception("Exercise not found");
            _dbContext.Exercises.Remove(exercise);
            _dbContext.SaveChanges();
            return Task.CompletedTask;
        }
        
    }
}
