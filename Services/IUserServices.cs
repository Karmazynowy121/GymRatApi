using GymRatApi.Commands.UserCommands;
using GymRatApi.Dto;
using GymRatApi.Entieties;
using GymRatApi.ModuleData.Commands.UserCommands;
using GymRatApi.ModuleData.Dto;
using Microsoft.AspNetCore.Identity;

namespace GymRatApi.Services
{
    public interface IUserServices
    {
       Task <UserDto> Create(UserCreateCommand userCreateCommand);
       Task<LoggedUserDto> Login(UserLogginCommand userLogginCommand);
       Task <List<UserDto>> GetAll();
       Task <UserDto> GetById(int id);
       Task Delete(int id);
       Task Update(UserUpdateCommand userUpdateCommand);
        
    }
}
