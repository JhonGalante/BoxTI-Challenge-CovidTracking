using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BoxTI.Challenge.CovidTracking.Services.CovidHostedService
{
    public interface ICovidHostedService
    {
        Task<JArray> getCountryCovidRegistry();
        Task<string> UpdateCountriesRegistry(DbContext context);
    }
}
