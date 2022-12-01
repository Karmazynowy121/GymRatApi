using GymRatApi.Entieties;

namespace GymRatApi.Services
{
    public interface IExerciseServices
    {
      Task<Exercise> Create(string name,string desctription);
      Task<List<Exercise>> GetAll();
      Task<Exercise> GetbyName(string name);
      Task Delete(int id);
    }
}
