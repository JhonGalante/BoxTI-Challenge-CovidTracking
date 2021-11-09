using BoxTI.Challenge.CovidTracking.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoxTI.Challenge.CovidTracking.API.Auth
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
