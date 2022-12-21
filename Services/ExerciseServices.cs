using AutoMapper;
using GymRatApi.Commands.ExerciseCommands;
using GymRatApi.Dto;
using GymRatApi.Entieties;
using Microsoft.EntityFrameworkCore;

namespace GymRatApi.Services
{
    public class ExerciseServices : BaseServices ,IExerciseServices
    {
        private readonly IMapper _mapper;
        public ExerciseServices(GymDbContext dbContext, IMapper mapper) 
            : base(dbContext)
        {
            _mapper = mapper;
        }

        public Task<ExerciseDto> Create(ExerciseCreateCommand exerciseCreateCommand)
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
            return Task.FromResult(_mapper.Map<ExerciseDto>(newExercise));
        }
        public Task<List<ExerciseDto>> GetAll()
            => Task.FromResult(_mapper.Map<List<ExerciseDto>>(_dbContext.Exercises.Include(e => e.Video).Include(e => e.BodyParts)
                .Include(e => e.Sport).ToList()));


        public Task<ExerciseDto> GetbyId(int exerciseId)
        {
            var exercise = _dbContext.Exercises.Where(g => g.Id == exerciseId)
                .Include(e => e.Video)
                .Include(e => e.BodyParts)
                .Include(e => e.Sport).FirstOrDefault();

            if (exercise == null)
            {
                throw new Exception($"Exercise {exerciseId} does not exist");
            }
            return Task.FromResult(_mapper.Map<ExerciseDto>(exercise));
        }

        public Task<ExerciseDto> GetbyName(string name)
        {
            var exercise = _dbContext.Exercises.Where(g => g.Name == name)
                .Include(e => e.Video)
                .Include(e => e.BodyParts)
                .Include(e => e.Sport).FirstOrDefault();

            if (exercise == null)
            {
                throw new Exception($"Exercise {name} does not exist");
            }
            return Task.FromResult(_mapper.Map<ExerciseDto>(exercise));
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
