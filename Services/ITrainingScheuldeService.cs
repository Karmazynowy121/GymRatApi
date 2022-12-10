using GymRatApi.Entieties;

namespace GymRatApi.Services
{
    public interface ITrainingScheuldeService
    {
        Task <TrainingScheulde> Create(User user, List<Training> trainings);
    }
}
