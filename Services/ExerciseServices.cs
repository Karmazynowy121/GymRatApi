using GymRatApi.Entieties;

namespace GymRatApi.Services
{
    public class ExerciseServices : BaseServices ,IExerciseServices
    {
        public ExerciseServices(GymDbContext dbContext) 
            : base(dbContext)
        {
        }

        public Task<Exercise> Create(string name, string description ,Video video,List<BodyPart> bodyParts)
        {
            if (string.IsNullOrEmpty(name) || (video == null) || (bodyParts == null))
            {
                throw new ArgumentNullException("name/video/bodyParts is null");
            }
            var newExercise = new Exercise() 
            { 
              Description = description,
              Name = name,
              Video = video, 
              Parts = bodyParts
            };
            _dbContext.Add(newExercise);
            _dbContext.SaveChanges();
            return Task.FromResult(newExercise);
        }
        public Task<List<Exercise>> GetAll () => Task.FromResult(_dbContext.Exercises.ToList());

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
