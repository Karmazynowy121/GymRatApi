using GymRatApi.Entieties;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymRatApi.Services
{
    public class UserServices : BaseServices,IUserServices
    {
        
        public UserServices(GymDbContext dbContext)
            : base(dbContext)
        {      
        }
        public Task<User> Create(string email,string password, string name)
        {
            if (string.IsNullOrEmpty(email)||string.IsNullOrEmpty(password)||string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("email or password is null");
            }
            var newUser = new User();
            newUser.Email = email;
            newUser.Password = password;
            newUser.Name = name;
            newUser.CreateAt = DateTime.Now;
            newUser.UpdateAt = DateTime.Now;
            _dbContext.Add(newUser);
            _dbContext.SaveChanges();
            return Task.FromResult(newUser);
        }
        public Task <List<User>> GetAll() =>Task.FromResult(_dbContext.Users.ToList());
        public async Task<User> GetById(int id)
        {

            var user = await _dbContext.Users.Where(g => g.Id == id)
                .Include(u => u.TrainingScheuldes)
                .ThenInclude(uts => uts.TrainingScheulde)
                .ThenInclude(ts => ts.Trainings).FirstOrDefaultAsync();
            if (user is null)
            {
                throw new Exception($"user {id} not found");
            }
            return user;   
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

        public Task Update(User user)
        {
            _dbContext.Update(user);
            _dbContext.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
