using BoxTI.Challenge.CovidTracking.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BoxTI.Challenge.CovidTracking.Services.Services
{
    public interface ICovidService
    {
        Task<JArray> getCountryCovidRegistry();
        Task<string> SaveCountriesRegistry();
    }
}
