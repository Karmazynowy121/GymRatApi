using GymRatApi.Commands;
using GymRatApi.Dto;
using GymRatApi.Entieties;

namespace GymRatApi.Services
{
    public interface IExerciseServices
    {
      Task<Exercise> Create(ExerciseCreateCommand exerciseCreateCommand);
      Task<List<Exercise>> GetAll();
      Task<Exercise> GetbyName(ExerciseGetDto exerciseGetDto);
      Task Delete(ExerciseDeleteCommand exerciseDeleteCommand);
    }
}
