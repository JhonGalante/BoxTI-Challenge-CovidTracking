using BoxTI.Challenge.CovidTracking.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BoxTI.Challenge.CovidTracking.Data.Repository
{
    public interface ICountryRegistryRepository
    {
        CountryRegistry GetByName(string name);
        Task<IList<dynamic>> GetOrderedByActiveCases();
    }
}
