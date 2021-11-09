using BoxTI.Challenge.CovidTracking.Models.Entities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace BoxTI.Challenge.CovidTracking.Client.Implementation
{
    public class MicroserviceAPIClient : IMicroserviceAPIClient
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MicroserviceAPIClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        #region CountryRegistry Endpoints

        public async Task<HttpResponseMessage> GetCountriesRegistryAsync(string token = null)
        {
            var client = _httpClientFactory.CreateClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("api/CountryRegistry"),
                Headers =
                {
                    {"Authorization", $"Bearer {token}"}
                },
            };

            var response = await client.SendAsync(request).ConfigureAwait(continueOnCapturedContext: false);

            return response;
        }

        public async Task<HttpResponseMessage> GetCountryRegistryByIdAsync(int id, string token = null)
        {
            var client = _httpClientFactory.CreateClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"api/CountryRegistry/{id}"),
                Headers =
                {
                    {"Authorization", $"Bearer {token}"}
                },
            };
            var response = await client.SendAsync(request).ConfigureAwait(continueOnCapturedContext: false);

            return response;
        }

        public async Task<HttpResponseMessage> GetOrderedActiveCasesAsync(string token = null)
        {
            var client = _httpClientFactory.CreateClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("api/CountryRegistry/getOrderedActiveCases"),
                Headers =
                {
                    {"Authorization", $"Bearer {token}"}
                },
            };
            var response = await client.SendAsync(request).ConfigureAwait(continueOnCapturedContext: false);

            return response;
        }

        public async Task<HttpResponseMessage> UpdateCountryRegistryAsync(int id, CountryRegistry obj, string token = null)
        {
            var client = _httpClientFactory.CreateClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri($"api/CountryRegistry/{id}"),
                Content = JsonContent.Create(obj),
                Headers =
                {
                    {"Authorization", $"Bearer {token}"}
                },
            };
            var response = await client.SendAsync(request).ConfigureAwait(continueOnCapturedContext: false);

            return response;
        }
        public async Task<HttpResponseMessage> DeleteCountryRegistryAsync(int id, string token = null)
        {
            var client = _httpClientFactory.CreateClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri($"api/CountryRegistry/{id}"),
                Headers =
                {
                    {"Authorization", $"Bearer {token}"}
                },
            };
            var response = await client.SendAsync(request).ConfigureAwait(continueOnCapturedContext: false);

            return response;
        }

        #endregion
    }
}
