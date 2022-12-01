using GymRatApi.Entieties;
using Microsoft.AspNetCore.Mvc;

namespace GymRatApi.Services
{
    public class UserServices : BaseServices,IUserServices
    {
        
        public UserServices(GymDbContext dbContext)
            : base(dbContext)
        {   
        }
        public Task<User> Create(string name, string email, string password)
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
        public Task<User> GetById(int id)
        {

            var user = _dbContext.Users.FirstOrDefault(g => g.Id == id);
            if (user is null)
            {
                throw new Exception($"user {id} not found");
            }
            return Task.FromResult(user);   
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

    }
}
