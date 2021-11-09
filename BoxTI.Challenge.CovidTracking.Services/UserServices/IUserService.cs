using BoxTI.Challenge.CovidTracking.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BoxTI.Challenge.CovidTracking.Services.UserServices
{
    public interface IUserService
    {
        User GetUser(string username, string password);
        Task<User> CreateUser(string username, string password);
    }
}
