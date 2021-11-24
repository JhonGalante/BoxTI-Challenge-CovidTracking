using BoxTI.Challenge.CovidTracking.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BoxTI.Challenge.CovidTracking.Services.CountryRegistryService
{
    public interface ICountryRegistryService
    {
        Task<IList<dynamic>> GetOrderedByActiveCases();
        Task<string> SaveCountriesRegistry();
        Task<IList<CountryRegistry>> GetAll();
        Task<CountryRegistry> GetById(int id);
        Task<CountryRegistry> Update(CountryRegistry cr);
        Task Delete(CountryRegistry cr);
        Task<string> ExportCountriesRegistryToCsv(CountryRegistry cr);
    }
}
