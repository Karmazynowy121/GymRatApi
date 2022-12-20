using GymRatApi.Commands.SportCommands;
using GymRatApi.Dto;
using GymRatApi.Entieties;

namespace GymRatApi.Services
{
    public interface ISportServices
    {
        Task<SportDto> Create(SportCreateCommand createSportCommand);
        Task<List<SportDto>> GetAll();
        Task<SportDto> GetById(int id);
        Task Delete(int id);
        Task Update(SportUpdateCommand sportUpdateCommand);
    }
}
