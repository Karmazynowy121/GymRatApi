using GymRatApi.Commands.BodyPartCommands;
using GymRatApi.Dto;
using GymRatApi.Entieties;
using Microsoft.AspNetCore.Mvc;

namespace GymRatApi.Services
{
    public interface IBodyPartService
    {
        Task<BodyPartDto> Create(BodyPartCreateCommand bodyPartCreateCommand);
        Task<List<BodyPartDto>> GetAll();
        Task<BodyPartDto> GetById(int id);
        Task Update (BodyPartUpdateCommand bodyPartUpdateCommand);
        Task Delete(int id);
        
    }
}
