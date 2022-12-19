using GymRatApi.Commands;
using GymRatApi.Entieties;

namespace GymRatApi.Services
{
    public interface ITrainingService
    {
        Task <Training> Create(TrainingCreateCommand trainingCreateCommand);
    }
}
