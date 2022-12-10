using GymRatApi.Entieties;

namespace GymRatApi.Services
{
    public interface ITrainingPartServices
    {
        Task<TrainingPart> Create(int amountSeries, int bodyWeight,int reps,int breakBetweenSeries, int exerciseId, int trainingId);
        Task<List<TrainingPart>> GetAll();
        Task Delete(int id);
        Task Update (TrainingPart part);
    }
}
