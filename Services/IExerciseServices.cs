using GymRatApi.ContractModules;
using GymRatApi.Entieties;

namespace GymRatApi.Services
{
    public interface IExerciseServices
    {
      Task<Exercise> Create(CreateExerciseContract createExerciseContract);
      Task<List<Exercise>> GetAll();
      Task<Exercise> GetbyName(string name);
      Task Delete(int id);
    }
}
