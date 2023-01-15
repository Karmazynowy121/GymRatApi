using AutoMapper;
using GymRatApi.Commands.UserCommands;
using GymRatApi.Dto;
using GymRatApi.Entieties;
using Microsoft.EntityFrameworkCore;

namespace GymRatApi.Services
{
    public class UserServices : BaseServices,IUserServices
    {
        private readonly IMapper _mapper;   
        public UserServices(GymDbContext dbContext, IMapper mapper)
            : base(dbContext)
        {
            _mapper = mapper;
        }
        public Task<UserDto> Create(UserCreateCommand userCreateCommand)
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
            return Task.FromResult(_mapper.Map<UserDto>(newUser));
        }
        public Task <List<UserDto>> GetAll() 
            =>Task.FromResult(_mapper.Map<List<UserDto>>(_dbContext.Users.ToList()));
        public async Task<UserDto> GetById(int id)
        {

            var user = await _dbContext.Users.Where(g => g.Id == id)
                .Include(u => u.TrainingScheuldes)
                .ThenInclude(uts => uts.TrainingScheulde)
                .ThenInclude(ts => ts.Trainings).FirstOrDefaultAsync();
            if (user is null)
            {
                throw new Exception($"user {id} not found");
            }
            return _mapper.Map<UserDto>(user);   
        }
        public Task Delete(int id)
        {
            var user = _dbContext
                .Users
                .FirstOrDefault(g => g.Id == id);
            if (user == null)
                throw new Exception("User not found");
            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
            return Task.CompletedTask;
        }

        public Task Update(UserUpdateCommand userUpdateCommand)
        {
            var user = _mapper.Map<User>(userUpdateCommand);
            _dbContext.Users.Update(user);
            _dbContext.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
