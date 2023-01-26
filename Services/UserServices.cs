using AutoMapper;
using GymRatApi.Commands.UserCommands;
using GymRatApi.Dto;
using GymRatApi.Entieties;
using GymRatApi.ModuleData.Commands.UserCommands;
using GymRatApi.ModuleData.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GymRatApi.Services
{
    public class UserServices : BaseServices,IUserServices
    {
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IMapper _mapper;   
        private readonly AuthenticationSettings _authenticationSettings;
        public UserServices(GymDbContext dbContext, IMapper mapper, IPasswordHasher<User> passwordHasher, AuthenticationSettings authenticationSettings)
            : base(dbContext)
        {
            _mapper = mapper;
            _passwordHasher = passwordHasher;
            _authenticationSettings = authenticationSettings;
        }
        public Task<UserDto> Create(UserCreateCommand userCreateCommand)
        {
            if (userCreateCommand == null)
            {
                throw new ArgumentNullException("userCreateCommand is null");
            }
            var newUser = new User();
            newUser.Email = userCreateCommand.Email;
            //newUser.Password = userCreateCommand.Password;
            newUser.Name = userCreateCommand.Name;
            newUser.CreateAt = DateTime.Now;
            newUser.UpdateAt = DateTime.Now;
            var hashedPassword = _passwordHasher.HashPassword(newUser, userCreateCommand.Password);
            newUser.Password = hashedPassword;
            _dbContext.Add(newUser);
            _dbContext.SaveChanges();
            return Task.FromResult(_mapper.Map<UserDto>(newUser));
        }
        public Task<LoggedUserDto> Login(LoginDto loginDto)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Name == loginDto.Name);
            if (user is null)
            {
                throw new Exception("invalid user or password");
            }
            var result = _passwordHasher.VerifyHashedPassword(user, user.Password, loginDto.Password);
            if (result == PasswordVerificationResult.Failed) 
            {
               throw new Exception("invalid user or password");
            }
            var claims = new List<Claim>() 
            { 
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim (ClaimTypes.Name, $"{user.Name}"),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);

            var token = new JwtSecurityToken(_authenticationSettings.JwtIssuer,
                _authenticationSettings.JwtIssuer,
                claims,
                expires: expires,
                signingCredentials: cred);

            var tokenHandler = new JwtSecurityTokenHandler();
            var basetoken = tokenHandler.WriteToken(token);
            var loggedUser = _mapper.Map<LoggedUserDto>(user);
            loggedUser.Jwt = basetoken;
            return Task.FromResult(loggedUser);
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
