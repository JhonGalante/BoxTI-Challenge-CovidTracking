using BoxTI.Challenge.CovidTracking.Data.Repository;
using BoxTI.Challenge.CovidTracking.Models.Entities;
using BoxTI.Challenge.CovidTracking.Services.CSVService;
using BoxTI.Challenge.CovidTracking.Services.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoxTI.Challenge.CovidTracking.Services.CountryRegistryService
{
    public class CountryRegistryService : ICountryRegistryService
    {
        private readonly ICountryRegistryRepository _repo;
        private readonly ICovidService _serviceCovid;
        private readonly IBaseService<CountryRegistry> _baseService;
        private readonly ICsvService _csvService;

        public CountryRegistryService(ICovidService serviceCovid,
                                      ICountryRegistryRepository repo,
                                      IBaseService<CountryRegistry> baseService,
                                      ICsvService csvService)
        {
            _repo = repo;
            _serviceCovid = serviceCovid;
            _baseService = baseService;
            _csvService = csvService;
        }

        public async Task<IList<dynamic>> GetOrderedByActiveCases()
        {
            return await _repo.GetOrderedByActiveCases();
        }

        public async Task<string> SaveCountriesRegistry()
        {
            return await _serviceCovid.SaveCountriesRegistry();
        }

        public async Task<IList<CountryRegistry>> GetAll()
        {
            return await _baseService.Get();
        }

        public async Task<CountryRegistry> GetById(int id)
        {
            return await _baseService.GetById(id);
        }

        public async Task<CountryRegistry> Update(CountryRegistry cr)
        {
            return await _baseService.Update(cr);
        }

        public async Task Delete(CountryRegistry cr)
        {
            await _baseService.Delete(cr);
        }

        public async Task<string> ExportCountriesRegistryToCsv(CountryRegistry cr)
        {
            return await _csvService.ExportCountriesRegistryToCsv(cr);
        }
    }
}
