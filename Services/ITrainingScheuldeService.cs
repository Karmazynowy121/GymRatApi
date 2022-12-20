using GymRatApi.Commands.TrainingScheuldeCommands;
using GymRatApi.Dto;
using GymRatApi.Entieties;

namespace GymRatApi.Services
{
    public interface ITrainingScheuldeService
    {
        Task <TrainingScheuldeDto> Create(TrainingScheuldeCreateCommand trainingScheuldeCreateCommand);
        Task Update(TrainingScheuldeUpdateCommand trainingScheuldeUpdateCommand);
        Task Delete(int id);
        Task<List<TrainingScheuldeDto>> GetAll();
    }
}
