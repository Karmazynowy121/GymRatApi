using GymRatApi.ContractModules;
using GymRatApi.Entieties;

namespace GymRatApi.Services
{
    public class SportServices : BaseServices, ISportServices
    {
        public SportServices(GymDbContext dbContext)
            : base(dbContext) 
        {
        }
        public Task<Sport> Create(CreateSportContract createSportContract)
        {
            if (createSportContract == null)
            {
                throw new ArgumentNullException("CreateSportContract is empty");
            }

            var rootExercise = _dbContext.Exercises.FirstOrDefault(ex => ex.Id == createSportContract.ExerciseId);
            if (rootExercise == null)
            {
                throw new Exception($"Exercise with id: {createSportContract.ExerciseId} does not exist");
            }

            var newSport = new Sport();
            newSport.Name = createSportContract.Name;
            newSport.ExerciseId = createSportContract.ExerciseId;
            newSport.Exercise = rootExercise;
            _dbContext.Add(newSport);
            _dbContext.SaveChanges();
            return Task.FromResult(newSport);
        }
        public Task<List<Sport>> GetAll() => Task.FromResult(_dbContext.Sports.ToList());
        public Task<Sport> GetById(int id)
        {

            var sport = _dbContext.Sports.FirstOrDefault(s => s.Id == id);
            if (sport is null)
            {
                throw new Exception($"sport {id} not found");
            }
            return Task.FromResult(sport);
        }
        public Task Delete(int id)
        {
            var sport = _dbContext
                .Sports
                .FirstOrDefault(s => s.Id == id);
            if (sport == null)
                throw new Exception("sport not found");
            _dbContext.Sports.Remove(sport);
            _dbContext.SaveChanges();
            return Task.CompletedTask;
        }
        public Task Update(CreateSportContract createSportContract)
        {
            _dbContext.Update(createSportContract);
            _dbContext.SaveChanges();
            return Task.CompletedTask;

        }
    }
}
