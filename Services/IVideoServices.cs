using GymRatApi.Commands;
using GymRatApi.Dto;
using GymRatApi.Entieties;

namespace GymRatApi.Services
{
    public interface IVideoServices
    {
        Task<Video> Create(VideoCreateCommand videoCreateCommand);
        Task<List<Video>> GetAll();
        Task<Video> GetById(VideoGetDto videoGetDto);
        Task Delete (VideoDeleteCommand videoDeleteCommand);
        Task Update (VideoUpdateCommand videoUpdateCommand);
    }
}
