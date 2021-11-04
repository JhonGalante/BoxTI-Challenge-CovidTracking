using BoxTI.Challenge.CovidTracking.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BoxTI.Challenge.CovidTracking.Services.Services
{
    public interface IExternalCovidService
    {
        Task<CountryRegistry> getCountryCovidRegistry(string name);
    }
}
