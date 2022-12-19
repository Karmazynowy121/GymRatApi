using GymRatApi.Commands;
using GymRatApi.Dto;
using GymRatApi.Entieties;

namespace GymRatApi.Services
{
    public interface IUserServices
    {
       Task <User> Create(UserCreateCommand userCreateCommand);
       Task <List<User>> GetAll();
       Task <User> GetById(UserGetDto userGetDto);
       Task Delete(UserDeleteCommand userDeleteCommand);
       Task Update(UserUpdateCommand userUpdateCommand);
        
    }
}
