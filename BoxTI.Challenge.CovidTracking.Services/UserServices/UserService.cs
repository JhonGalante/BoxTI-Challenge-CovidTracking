using BoxTI.Challenge.CovidTracking.Data.Repository.UserRepository;
using BoxTI.Challenge.CovidTracking.Models.Entities;
using BoxTI.Challenge.CovidTracking.Services.HashService;
using System.Threading.Tasks;

namespace BoxTI.Challenge.CovidTracking.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;
        private readonly IHashService _hashService;

        public UserService(IUserRepository userRepo, IHashService hashService)
        {
            _userRepo = userRepo;
            _hashService = hashService;
        }

        public async Task<User> CreateUser(string username, string password)
        {
            var user = await _userRepo.CreateUser(new User
            {
                Username = username,
                Password = _hashService.CalculateHash(password),
                Role = "comum"
            });
           
            return user;
        }

        public User GetUser(string username, string password)
        {
            return _userRepo.Get(username, _hashService.CalculateHash(password));
        }
    }
}
