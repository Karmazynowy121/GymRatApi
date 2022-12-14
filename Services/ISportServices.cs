using GymRatApi.ContractModules;
using GymRatApi.Entieties;

namespace GymRatApi.Services
{
    public interface ISportServices
    {
        Task<Sport> Create(CreateSportContract createSportContract);
        Task<List<Sport>> GetAll();
        Task<Sport> GetById(int id);
        Task Delete(int id);
        Task Update(CreateSportContract createSportContract);
    }
}
