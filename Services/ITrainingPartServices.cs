using GymRatApi.ContractModules;
using GymRatApi.Entieties;

namespace GymRatApi.Services
{
    public interface ITrainingPartServices
    {
        Task<TrainingPart> Create(CreateTrainingPartContract createTrainingPartContract);
        Task<List<TrainingPart>> GetAll();
        Task Delete(int id);
        Task Update (TrainingPart part);
    }
}
