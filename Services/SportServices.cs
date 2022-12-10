using GymRatApi.Entieties;

namespace GymRatApi.Services
{
    public class SportServices : BaseServices, ISportServices
    {
        public SportServices(GymDbContext dbContext)
            : base(dbContext) 
        {
        }
        public Task<Sport> Create(string name, int exerciseId)
        {
            if (string.IsNullOrEmpty(name) || exerciseId < 0)
            {
                throw new ArgumentNullException("Name is empty");
            }

            var rootExercise = _dbContext.Exercises.FirstOrDefault(ex => ex.Id == exerciseId);
            if (rootExercise == null)
            {
                throw new Exception($"Exercise with id: {exerciseId} does not exist");
            }

            var newSport = new Sport();
            newSport.Name = name;
            newSport.ExerciseId = exerciseId;
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
        public Task Update(Sport sport)
        {
            _dbContext.Update(sport);
            _dbContext.SaveChanges();
            return Task.CompletedTask;

        }
    }
}
