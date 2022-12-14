using GymRatApi.ContractModules;
using GymRatApi.Entieties;

namespace GymRatApi.Services
{
    public interface IBodyPartService
    {
        Task<BodyPart> Create(CreateBodyPartContract createBodyPartContract);
        Task<List<BodyPart>> GetAll();
        Task<BodyPart> GetById(int id);
        Task Delete(int id);
        Task Update (BodyPart bodyPart);
    }
}
