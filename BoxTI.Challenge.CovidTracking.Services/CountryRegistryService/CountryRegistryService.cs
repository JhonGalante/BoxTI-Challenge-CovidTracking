using BoxTI.Challenge.CovidTracking.Data.Repository;
using BoxTI.Challenge.CovidTracking.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BoxTI.Challenge.CovidTracking.Services.CountryRegistryService
{
    public class CountryRegistryService : ICountryRegistryService
    {
        private readonly ICountryRegistryRepository _repo;

        public CountryRegistryService(ICountryRegistryRepository repo)
        {
            _repo = repo;
        }

        public async Task<IList<dynamic>> GetOrderedByActiveCases()
        {
            return await _repo.GetOrderedByActiveCases();
        }
    }
}
