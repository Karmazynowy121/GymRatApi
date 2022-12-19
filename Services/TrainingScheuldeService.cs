using AutoMapper;
using GymRatApi.Commands.TrainingScheuldeCommands;
using GymRatApi.Dto;
using GymRatApi.Entieties;
using Microsoft.EntityFrameworkCore;

namespace GymRatApi.Services
{
    public class TrainingScheuldeService :BaseServices, ITrainingScheuldeService
    {
        private readonly IMapper _mapper;
        public TrainingScheuldeService(GymDbContext dbContext, IMapper mapper)
            : base(dbContext)
        {
            _mapper = mapper;
        }

        public async Task<TrainingScheuldeDto> Create (TrainingScheuldeCreateCommand trainingScheuldeCreateCommand)
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
           
            return _mapper.Map<TrainingScheuldeDto>(newTrainingScheulde);
        }
        public Task Update(TrainingScheuldeUpdateCommand trainingScheuldeUpdateCommand)
        {
            _dbContext.Update(trainingScheuldeUpdateCommand);
            _dbContext.SaveChanges();
            return Task.CompletedTask;

        }
        public Task Delete(int id)
        {
            var trainingScheulde = _dbContext
                .TrainingScheulde
                .FirstOrDefault(t => t.Id == id);
            if (trainingScheulde == null)
                throw new Exception("trainingScheulde not found");
            _dbContext.TrainingScheulde.Remove(trainingScheulde);
            _dbContext.SaveChanges();
            return Task.CompletedTask;
        }
        public Task<List<TrainingScheuldeDto>> GetAll() 
            => Task.FromResult(_mapper.Map <List<TrainingScheuldeDto>>(_dbContext.TrainingScheulde.ToList()));
    }
}
