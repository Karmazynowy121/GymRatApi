using AutoMapper;
using GymRatApi.Commands.SportCommands;
using GymRatApi.Dto;
using GymRatApi.Entieties;

namespace GymRatApi.Services
{
    public class SportServices : BaseServices, ISportServices
    {
        private readonly IMapper _mapper;
        public SportServices(GymDbContext dbContext, IMapper mapper)
            : base(dbContext) 
        {
            _mapper = mapper;
        }
        public Task<SportDto> Create(SportCreateCommand createSportCommand)
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
            return Task.FromResult(_mapper.Map<SportDto>(newSport));
        }
        public Task<List<Sport>> GetAll() => Task.FromResult(_dbContext.Sports.ToList());
        public Task<Sport> GetById(int id)
        {

            var sport = _dbContext.Sports.FirstOrDefault(s => s.Id == id);
            if (sport is null)
            {
                throw new Exception($"sport {id} not found");
            }
            return Task.FromResult(_mapper.Map<SportDto>(sport));
        }
        public Task Delete(int id)
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
