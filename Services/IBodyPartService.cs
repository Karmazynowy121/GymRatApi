using GymRatApi.Commands;
using GymRatApi.Dto;
using GymRatApi.Entieties;

namespace GymRatApi.Services
{
    public interface IBodyPartService
    {
        Task<BodyPart> Create(BodyPartCreateCommand bodyPartCreateCommand);
        Task<List<BodyPart>> GetAll();
        Task<BodyPart> GetById(BodyPartGetDto bodyPartGetDto);
        Task Update (BodyPartUpdateCommand bodyPartUpdateCommand);
        Task Delete(BodyPartDeleteCommand bodyPartDeleteCommand);
    }
}
