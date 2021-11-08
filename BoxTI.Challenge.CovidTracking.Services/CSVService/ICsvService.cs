using BoxTI.Challenge.CovidTracking.Models.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BoxTI.Challenge.CovidTracking.Services.CSVService
{
    public interface ICsvService
    {
        Task<string> exportCountriesRegistryToCsv(CountryRegistry countryToExport);
    }
}
