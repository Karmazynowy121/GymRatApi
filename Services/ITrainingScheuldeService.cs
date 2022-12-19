using GymRatApi.Commands;
using GymRatApi.Entieties;

namespace GymRatApi.Services
{
    public interface ITrainingScheuldeService
    {
        Task <TrainingScheulde> Create(TrainingScheuldeCreateCommand trainingScheuldeCreateCommand);
        Task Update(TrainingScheuldeUpdateCommand trainingScheuldeUpdateCommand);
        Task Delete(TrainingScheuldeDeleteCommand trainingScheuldeDeleteCommand);
        Task<List<TrainingScheulde>> GetAll();
    }
}
