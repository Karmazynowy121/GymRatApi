using GymRatApi.Commands;
using GymRatApi.Dto;
using GymRatApi.Entieties;

namespace GymRatApi.Services
{
    public class SportServices : BaseServices, ISportServices
    {
        public SportServices(GymDbContext dbContext)
            : base(dbContext) 
        {
        }
        public Task<Sport> Create(CreateSportCommand createSportCommand)
        {
            if (createSportCommand == null)
            {
                throw new ArgumentNullException("CreateSportContract is empty");
            }

            var rootExercise = _dbContext.Exercises.FirstOrDefault(ex => ex.Id == createSportCommand.ExerciseId);
            if (rootExercise == null)
            {
                throw new Exception($"Exercise with id: {createSportCommand.ExerciseId} does not exist");
            }

            var newSport = new Sport();
            newSport.Name = createSportCommand.Name;
            newSport.ExerciseId = createSportCommand.ExerciseId;
            newSport.Exercise = rootExercise;
            _dbContext.Add(newSport);
            _dbContext.SaveChanges();
            return Task.FromResult(newSport);
        }
        public Task<List<Sport>> GetAll() => Task.FromResult(_dbContext.Sports.ToList());
        public Task<Sport> GetById(SportGetDto sportGetDto)
        {

            var sport = _dbContext.Sports.FirstOrDefault(s => s.Id == sportGetDto.Id);
            if (sport is null)
            {
                throw new Exception($"sport {sportGetDto} not found");
            }
            return Task.FromResult(sport);
        }
        public Task Delete(SportDeleteCommand sportDeleteCommand)
        {
            var sport = _dbContext
                .Sports
                .FirstOrDefault(s => s.Id == sportDeleteCommand.Id);
            if (sport == null)
                throw new Exception("sport not found");
            _dbContext.Sports.Remove(sport);
            _dbContext.SaveChanges();
            return Task.CompletedTask;
        }
        public Task Update(SportUpdateCommand sportUpdateCommand)
        {
            _dbContext.Update(sportUpdateCommand);
            _dbContext.SaveChanges();
            return Task.CompletedTask;

        }
    }
}
