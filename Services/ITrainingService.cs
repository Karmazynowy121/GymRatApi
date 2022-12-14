using GymRatApi.ContractModules;
using GymRatApi.Entieties;

namespace GymRatApi.Services
{
    public interface ITrainingService
    {
        Task <Training> Create(CreateTrainingContract createTrainingContract);
    }
}
