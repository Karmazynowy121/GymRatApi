using GymRatApi.Entieties;

namespace GymRatApi.Services
{
    public interface IBodyPartService
    {
        Task<BodyPart> Create(string name, int howManyExercisePerWeek, int exerciseId);
        Task<List<BodyPart>> GetAll();
        Task<BodyPart> GetById(int id);
        Task Delete(int id);
        Task Update (BodyPart bodyPart);
    }
}
