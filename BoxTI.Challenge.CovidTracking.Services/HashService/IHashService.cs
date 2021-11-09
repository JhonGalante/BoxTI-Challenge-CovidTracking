using System;
using System.Collections.Generic;
using System.Text;

namespace BoxTI.Challenge.CovidTracking.Services.HashService
{
    public interface IHashService
    {
        string CalculaHash(string Senha);
    }
}
