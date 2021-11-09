using BoxTI.Challenge.CovidTracking.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BoxTI.Challenge.CovidTracking.Data.Repository.UserRepository
{
    public interface IUserRepository
    {
        User Get(string username, string password);

        Task<User> CreateUser(User user);
    }
}
