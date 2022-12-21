using GymRatApi.Commands.ExerciseCommands;
using GymRatApi.Dto;
using GymRatApi.Entieties;

namespace GymRatApi.Services
{
    public interface IExerciseServices
    {
      Task<ExerciseDto> Create(ExerciseCreateCommand exerciseCreateCommand);
      Task<List<ExerciseDto>> GetAll();
      Task<ExerciseDto> GetbyName(string name);
      Task<Exercise> GetbyId(int exerciseId);
      Task Delete(int id);
    }
}
