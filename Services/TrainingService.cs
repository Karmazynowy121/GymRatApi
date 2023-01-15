using AutoMapper;
using GymRatApi.Commands.TrainingCommands;
using GymRatApi.Dto;
using GymRatApi.Entieties;
using Microsoft.EntityFrameworkCore;

namespace GymRatApi.Services
{
    public class TrainingService : BaseServices, ITrainingService
    {
        private readonly IMapper _mapper;
        public TrainingService(GymDbContext dbContext, IMapper mapper) 
            : base(dbContext)
        {
            _mapper = mapper;
        }

        public Task<TrainingDto> Create(TrainingCreateCommand trainingCreateCommand)
        {
            if (trainingCreateCommand == null)
            {
                throw new ArgumentNullException("CreateTrainingContract is empty");
            }

            var trainingScheuldeFromDb = _dbContext.TrainingScheulde.FirstOrDefault(ts => ts.Id == trainingCreateCommand.TrainingScheudleId);

            if (trainingScheuldeFromDb == null)
            {
                throw new ArgumentNullException("TrainingScheulde is empty");
            }

            var newTraining = new Training();
            newTraining.Description = trainingCreateCommand.Description;
            newTraining.TrainingDate = trainingCreateCommand.TrainingDate;
            newTraining.Interval = trainingCreateCommand.Interval;
            newTraining.TrainingDuration = trainingCreateCommand.TrainingDuration;
            newTraining.TrainingScheulde = trainingScheuldeFromDb;
            newTraining.TrainingScheuldeId = trainingScheuldeFromDb.Id;

            _dbContext.Add(newTraining);
            _dbContext.SaveChanges();
            return Task.FromResult(_mapper.Map<TrainingDto>(newTraining));
        }
        public Task<List<TrainingDto>> GetAll()
          => Task.FromResult(_mapper.Map<List<TrainingDto>>(_dbContext.Training.ToList()));
        
        public Task Update(TrainingUpdateCommand trainingUpdateCommand)
        {
            var training = _mapper.Map<Training>(trainingUpdateCommand);
            _dbContext.Training.Update(training);
            return Task.CompletedTask;
        }
    }
}
