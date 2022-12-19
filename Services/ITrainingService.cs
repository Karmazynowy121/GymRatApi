using GymRatApi.Commands.TrainingCommands;
using GymRatApi.Dto;

namespace GymRatApi.Services
{
    public interface ITrainingService
    {
        Task <TrainingDto> Create(TrainingCreateCommand trainingCreateCommand);
    }
}
