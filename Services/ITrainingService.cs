using GymRatApi.ContractModules;
using GymRatApi.Entieties;

namespace GymRatApi.Services
{
    public interface ITrainingService
    {
        Task <Training> Create(List<CreateTrainingPartContract> trainingParts, string description, DateTime trainingDate, int interval);
    }
}
