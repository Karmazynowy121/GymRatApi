using GymRatApi.Commands.TrainingPartCommands;
using GymRatApi.Dto;
using GymRatApi.Entieties;

namespace GymRatApi.Services
{
    public interface ITrainingPartServices
    {
        Task<TrainingPartDto> Create(TrainingPartCreateCommand trainingPartCreateCommand);
        Task<List<TrainingPartDto>> GetAll();
        Task Delete(int id);
        Task Update (TrainingPartUpdateCommand trainingPartUpdateCommand);
    }
}
