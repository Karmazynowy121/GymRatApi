using GymRatApi.Commands.UserCommands;
using GymRatApi.Dto;
using GymRatApi.Entieties;

namespace GymRatApi.Services
{
    public interface IUserServices
    {
       Task <UserDto> Create(UserCreateCommand userCreateCommand);
       Task <List<UserDto>> GetAll();
       Task <UserDto> GetById(int id);
       Task Delete(int id);
       Task Update(UserUpdateCommand userUpdateCommand);
        
    }
}
