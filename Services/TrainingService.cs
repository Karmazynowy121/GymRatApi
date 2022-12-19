using AutoMapper;
using GymRatApi.Commands.TrainingCommands;
using GymRatApi.Dto;
using GymRatApi.Entieties;

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
            var newTraining = new Training();
            newTraining.Description = trainingCreateCommand.Description;
            newTraining.TrainingDate = trainingCreateCommand.TrainingDate;
            newTraining.Interval = trainingCreateCommand.Interval;
            newTraining.TrainingDuration = trainingCreateCommand.TrainingDuration;
            _dbContext.Add(newTraining);
            _dbContext.SaveChanges();
            return Task.FromResult(_mapper.Map<TrainingDto>(newTraining));
        }
    }
}
