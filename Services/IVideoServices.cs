using GymRatApi.ContractModules;
using GymRatApi.Entieties;

namespace GymRatApi.Services
{
    public interface IVideoServices
    {
        Task<Video> Create(CreateBaseVideoContract createBaseVideoContract);
        Task<List<Video>> GetAll();
        Task<Video> GetById(int id);
        Task Delete (int id);
        Task Update (Video video);
    }
}
