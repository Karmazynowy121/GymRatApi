using GymRatApi.ContractModules;
using GymRatApi.Entieties;

namespace GymRatApi.Services
{
    public interface ITrainingScheuldeService
    {
        Task <TrainingScheulde> Create(CreateTrainingScheuldeContract createTrainingScheuldeContract);
        Task Update(CreateTrainingScheuldeContract createTrainingScheuldeContract);
        Task Delete(int id);
        Task<List<TrainingScheulde>> GetAll();
    }
}
