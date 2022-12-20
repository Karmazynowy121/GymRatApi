using GymRatApi.Commands.VideoCommands;
using GymRatApi.Dto;
using GymRatApi.Entieties;

namespace GymRatApi.Services
{
    public interface IVideoServices
    {
        Task<VideoDto> Create(VideoCreateCommand videoCreateCommand);
        Task<List<VideoDto>> GetAll();
        Task<VideoDto> GetById(int id);
        Task Delete (int id);
        Task Update (VideoUpdateCommand videoUpdateCommand);
    }
}
