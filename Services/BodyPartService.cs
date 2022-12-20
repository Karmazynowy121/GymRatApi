using AutoMapper;
using GymRatApi.Commands.BodyPartCommands;
using GymRatApi.Dto;
using GymRatApi.Entieties;

namespace GymRatApi.Services
{
    public class BodyPartService : BaseServices, IBodyPartService 
    {
        private readonly IMapper _mapper;
        public BodyPartService(GymDbContext dbContext, IMapper mapper) 
            : base(dbContext)
        {
            _mapper = mapper;
        }

        public Task<BodyPartDto>Create (BodyPartCreateCommand bodyPartCreateCommand)
        {
            if (bodyPartCreateCommand == null)
            {
                throw new ArgumentException("createBodyPartContract is empty");
            }
            var rootExercise = _dbContext.Exercises.FirstOrDefault(ex => ex.Id == bodyPartCreateCommand.ExerciseId);

            if (rootExercise == null)
            {
                throw new Exception($"Exercise with id: {bodyPartCreateCommand.ExerciseId} does not exist");
            }
            var newBodyPart = new BodyPart();
            newBodyPart.Name = bodyPartCreateCommand.Name;
            newBodyPart.HowManyExercisesPerWeek = bodyPartCreateCommand.HowManyExercisePerWeek;
            newBodyPart.ExerciseId = bodyPartCreateCommand.ExerciseId;
            newBodyPart.Exercise = rootExercise;
            _dbContext.Add(newBodyPart);
            _dbContext.SaveChanges();
            return Task.FromResult(_mapper.Map<BodyPartDto>(newBodyPart));
        }
        public Task<List<BodyPartDto>> GetAll() 
            => Task.FromResult(_mapper.Map<List<BodyPartDto>>(_dbContext.BodyParts.ToList()));

        public Task<BodyPartDto> GetById(int id)
        {
            



            var bodyPart = _dbContext.BodyParts.FirstOrDefault(b => b.Id == id);
            if (bodyPart is null)
            {
                throw new Exception($"bodyPart {id} not found");
            }
            return Task.FromResult(_mapper.Map<BodyPartDto>(bodyPart));
        }
        public Task Delete(int id)
        {
            var bodyPart = _dbContext
                .BodyParts
                .FirstOrDefault(b => b.Id == id);
            if (bodyPart == null)
                throw new Exception("BodyPart not found");
            _dbContext.BodyParts.Remove(bodyPart);
            _dbContext.SaveChanges();
            return Task.CompletedTask;
        }
        public Task Update(BodyPartUpdateCommand bodyPartUpdateCommand)
        {
            _dbContext.Update(bodyPartUpdateCommand);
            _dbContext.SaveChanges();
            return Task.CompletedTask;

        }
    }
}
