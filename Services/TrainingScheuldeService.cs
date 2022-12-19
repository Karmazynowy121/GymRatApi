using GymRatApi.Commands;
using GymRatApi.Entieties;
using Microsoft.EntityFrameworkCore;

namespace GymRatApi.Services
{
    public class TrainingScheuldeService :BaseServices, ITrainingScheuldeService
    {
        public TrainingScheuldeService(GymDbContext dbContext)
            : base(dbContext)
        {
        }

        public async Task<TrainingScheulde> Create (TrainingScheuldeCreateCommand trainingScheuldeCreateCommand)
        {
            if (trainingScheuldeCreateCommand == null)
            {
                throw new ArgumentNullException("user or training is null");
            }

            var userFormDb = await _dbContext.Users.Where(u => u.Id == trainingScheuldeCreateCommand.UserId)
                .Include(u => u.TrainingScheuldes).ThenInclude(ts => ts.TrainingScheulde).FirstOrDefaultAsync();

            if (userFormDb == null)
            {
                throw new Exception("can find a user");
            }

            // robimy nowy szablon dla listy treningowej 
            var newTrainingScheulde = new TrainingScheulde();
            newTrainingScheulde.Name = trainingScheuldeCreateCommand.Name;
            _dbContext.Add(newTrainingScheulde);
            _dbContext.SaveChanges();

            // jak już mamy liste zrobiona to probujemy utworzyć tablice laczaca
            var newUserTrainingScheulde = new UserTrainingScheulde()
            {
                UserId = trainingScheuldeCreateCommand.UserId,
                User = userFormDb,
                TrainingScheulde = newTrainingScheulde,
                TrainingScheuldeId = newTrainingScheulde.Id
            };
            _dbContext.Add(newUserTrainingScheulde);
            _dbContext.SaveChanges();

            // update dla obu encji 
            userFormDb.TrainingScheuldes.Add(newUserTrainingScheulde);
            newTrainingScheulde.User = newUserTrainingScheulde;
            _dbContext.Update(userFormDb);
            _dbContext.Update(newTrainingScheulde);
           
            return newTrainingScheulde;
        }
        public Task Update(TrainingScheuldeUpdateCommand trainingScheuldeUpdateCommand)
        {
            _dbContext.Update(trainingScheuldeUpdateCommand);
            _dbContext.SaveChanges();
            return Task.CompletedTask;

        }
        public Task Delete(TrainingScheuldeDeleteCommand trainingScheuldeDeleteCommand)
        {
            var trainingScheulde = _dbContext
                .TrainingScheulde
                .FirstOrDefault(t => t.Id == trainingScheuldeDeleteCommand.Id);
            if (trainingScheulde == null)
                throw new Exception("trainingScheulde not found");
            _dbContext.TrainingScheulde.Remove(trainingScheulde);
            _dbContext.SaveChanges();
            return Task.CompletedTask;
        }
        public Task<List<TrainingScheulde>> GetAll() => Task.FromResult(_dbContext.TrainingScheulde.ToList());
    }
}
