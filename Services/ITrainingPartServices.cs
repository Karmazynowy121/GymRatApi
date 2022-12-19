using GymRatApi.Commands;
using GymRatApi.Entieties;

namespace GymRatApi.Services
{
    public interface ITrainingPartServices
    {
        Task<TrainingPart> Create(TrainingPartCreateCommand trainingPartCreateCommand);
        Task<List<TrainingPart>> GetAll();
        Task Delete(TrainingPartDeleteCommand trainingPartDeleteCommand);
        Task Update (TrainingPartUpdateCommand trainingPartUpdateCommand);
    }
}
