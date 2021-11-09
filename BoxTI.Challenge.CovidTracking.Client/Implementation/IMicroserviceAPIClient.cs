using BoxTI.Challenge.CovidTracking.Models.Entities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BoxTI.Challenge.CovidTracking.Client.Implementation
{
    public interface IMicroserviceAPIClient
    {
        #region CountryRegistry Endpoints
        Task<HttpResponseMessage> GetOrderedActiveCasesAsync(string token = null);
        Task<HttpResponseMessage> GetCountriesRegistryAsync(string token = null);
        Task<HttpResponseMessage> GetCountryRegistryByIdAsync(int id, string token = null);
        Task<HttpResponseMessage> UpdateCountryRegistryAsync(int id, CountryRegistry request, string token = null);
        Task<HttpResponseMessage> DeleteCountryRegistryAsync(int id, string token = null);
        #endregion
    }
}
