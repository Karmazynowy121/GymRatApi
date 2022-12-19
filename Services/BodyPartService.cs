using GymRatApi.Commands;
using GymRatApi.Dto;
using GymRatApi.Entieties;

namespace GymRatApi.Services
{
    public class BodyPartService : BaseServices, IBodyPartService 
    {
        public BodyPartService(GymDbContext dbContext) 
            : base(dbContext)
        {
        }

        public Task<BodyPart>Create (BodyPartCreateCommand bodyPartCreateCommand)
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
            return Task.FromResult(newBodyPart);
        }
        public Task<List<BodyPart>> GetAll() => Task.FromResult(_dbContext.BodyParts.ToList());
        public Task<BodyPart> GetById(BodyPartGetDto bodyPartGetDto)
        {

            var bodyPart = _dbContext.BodyParts.FirstOrDefault(b => b.Id == bodyPartGetDto.Id);
            if (bodyPart is null)
            {
                throw new Exception($"bodyPart {bodyPartGetDto} not found");
            }
            return Task.FromResult(bodyPart);
        }
        public Task Delete(BodyPartDeleteCommand bodyPartDeleteCommand)
        {
            var bodyPart = _dbContext
                .BodyParts
                .FirstOrDefault(b => b.Id ==  bodyPartDeleteCommand.Id);
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
