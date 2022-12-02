using GymRatApi.Entieties;

namespace GymRatApi.Services
{
    public interface IUserServices
    {
       Task <User> Create(string name,string email, string password);
       Task <List<User>> GetAll();
       Task <User> GetById(int id);
       Task Delete(int id);
       Task Update(User user);
        
    }
}
