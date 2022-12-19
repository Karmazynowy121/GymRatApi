using GymRatApi.Commands;
using GymRatApi.Dto;
using GymRatApi.Entieties;
using Microsoft.EntityFrameworkCore;

namespace GymRatApi.Services
{
    public class UserServices : BaseServices,IUserServices
    {
        
        public UserServices(GymDbContext dbContext)
            : base(dbContext)
        {      
        }
        public Task<User> Create(UserCreateCommand userCreateCommand)
        {
            if (userCreateCommand == null)
            {
                throw new ArgumentNullException("userCreateCommand is null");
            }
            var newUser = new User();
            newUser.Email = userCreateCommand.Email;
            newUser.Password = userCreateCommand.Password;
            newUser.Name = userCreateCommand.Name;
            newUser.CreateAt = DateTime.Now;
            newUser.UpdateAt = DateTime.Now;
            _dbContext.Add(newUser);
            _dbContext.SaveChanges();
            return Task.FromResult(newUser);
        }
        public Task <List<User>> GetAll() =>Task.FromResult(_dbContext.Users.ToList());
        public async Task<User> GetById(UserGetDto userGetDto)
        {

            var user = await _dbContext.Users.Where(g => g.Id == userGetDto.Id)
                .Include(u => u.TrainingScheuldes)
                .ThenInclude(uts => uts.TrainingScheulde)
                .ThenInclude(ts => ts.Trainings).FirstOrDefaultAsync();
            if (user is null)
            {
                throw new Exception($"user {userGetDto} not found");
            }
            return user;   
        }
        public Task Delete(UserDeleteCommand userDeleteCommand)
        {
            var user = _dbContext
                .Users
                .FirstOrDefault(g => g.Id == userDeleteCommand.Id);
            if (user == null)
                throw new Exception("User not found");
            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
            return Task.CompletedTask;
        }

        public Task Update(UserUpdateCommand userUpdateCommand)
        {
            _dbContext.Update(userUpdateCommand);
            _dbContext.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
