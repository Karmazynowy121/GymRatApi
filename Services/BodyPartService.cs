using GymRatApi.Entieties;

namespace GymRatApi.Services
{
    public class BodyPartService : BaseServices, IBodyPartService 
    {
        public BodyPartService(GymDbContext dbContext) 
            : base(dbContext)
        {
        }

        public Task<BodyPart>Create (string name, int howManyExercisePerWeek, int exerciseId)
        {
            if (string.IsNullOrEmpty(name) || howManyExercisePerWeek < 0|| exerciseId < 0)
            {
                throw new ArgumentException("Name or ExercisePerWeek is empty");
            }
            var rootExercise = _dbContext.Exercises.FirstOrDefault(ex => ex.Id == exerciseId);

            if (rootExercise == null)
            {
                throw new Exception($"Exercise with id: {exerciseId} does not exist");
            }
            var newBodyPart = new BodyPart();
            newBodyPart.Name = name;
            newBodyPart.HowManyExercisesPerWeek = howManyExercisePerWeek;
            newBodyPart.ExerciseId = exerciseId;
            newBodyPart.Exercise = rootExercise;
            _dbContext.Add(newBodyPart);
            _dbContext.SaveChanges();
            return Task.FromResult(newBodyPart);
        }
        public Task<List<BodyPart>> GetAll() => Task.FromResult(_dbContext.BodyParts.ToList());
        public Task<BodyPart> GetById(int id)
        {

            var bodyPart = _dbContext.BodyParts.FirstOrDefault(b => b.Id == id);
            if (bodyPart is null)
            {
                throw new Exception($"bodyPart {id} not found");
            }
            return Task.FromResult(bodyPart);
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
        public Task Update(BodyPart bodyPart)
        {
            _dbContext.Update(bodyPart);
            _dbContext.SaveChanges();
            return Task.CompletedTask;

        }
    }
}
