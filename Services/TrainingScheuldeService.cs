using GymRatApi.Entieties;

namespace GymRatApi.Services
{
    public class TrainingScheuldeService :BaseServices, ITrainingScheuldeService
    {
        public TrainingScheuldeService(GymDbContext dbContext)
            : base(dbContext)
        {
        }

        public Task<TrainingScheulde> Create (User user, List<Training> trainings)
        {
            if ((user == null) || (trainings == null))
            {
                throw new ArgumentNullException("user or training is null");
            }
            var newTrainingScheulde = new TrainingScheulde();
            newTrainingScheulde.User = user;
            newTrainingScheulde.Trainings.Add(new Training());
            _dbContext.Add(newTrainingScheulde);
            _dbContext.SaveChanges();
            return Task.FromResult(newTrainingScheulde);
        }
    }
}
