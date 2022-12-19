using GymRatApi.Commands;
using GymRatApi.Dto;
using GymRatApi.Entieties;

namespace GymRatApi.Services
{
    public interface ISportServices
    {
        Task<Sport> Create(CreateSportCommand createSportCommand);
        Task<List<Sport>> GetAll();
        Task<Sport> GetById(SportGetDto sportGetDto);
        Task Delete(SportDeleteCommand sportDeleteCommand);
        Task Update(SportUpdateCommand sportUpdateCommand);
    }
}
