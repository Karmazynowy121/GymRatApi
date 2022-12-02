using GymRatApi.Entieties;

namespace GymRatApi.Services
{
    public interface IVideoServices
    {
        Task<Video> Create(string title, string path, int exerciseId);
        Task<List<Video>> GetAll();
        Task<Video> GetById(int id);
        Task Delete (int id);
        Task Update (Video video);
    }
}
