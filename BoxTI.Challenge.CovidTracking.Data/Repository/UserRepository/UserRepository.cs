using BoxTI.Challenge.CovidTracking.Data.Context;
using BoxTI.Challenge.CovidTracking.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxTI.Challenge.CovidTracking.Data.Repository.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly MySqlContext _context;

        public UserRepository(MySqlContext context)
        {
            _context = context;
        }
        public User Get(string username, string password)
        {
            return _context.Users.Where(x => x.Username.ToLower() == username.ToLower()).Where(x => x.Password == password).FirstOrDefault();
        }

        public async Task<User> CreateUser(User user)
        {
            if(_context.Users.Where(x => x.Username.ToLower() == user.Username).Any())
            {
                return null;
            }

            await _context.Users.AddAsync(user);

            await _context.SaveChangesAsync();

            return user;
        }
    }
}
