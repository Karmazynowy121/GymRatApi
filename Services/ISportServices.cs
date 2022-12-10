using GymRatApi.Entieties;

namespace GymRatApi.Services
{
    public interface ISportServices
    {
        Task<Sport> Create(string name, int exerciseId);
        Task<List<Sport>> GetAll();
        Task<Sport> GetById(int id);
        Task Delete(int id);
        Task Update(Sport sport);
    }
}
