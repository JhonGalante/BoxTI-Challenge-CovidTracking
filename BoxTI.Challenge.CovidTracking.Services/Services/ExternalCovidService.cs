using BoxTI.Challenge.CovidTracking.Models.Entities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BoxTI.Challenge.CovidTracking.Services.Services
{
    public class ExternalCovidService : IExternalCovidService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly string covidAPI;

        public ExternalCovidService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            covidAPI = "https://covid-19-tracking.p.rapidapi.com/v1/";
        }

        public async Task<CountryRegistry> getCountryCovidRegistry(string name)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, covidAPI + name);
            request.Headers.Add("x-rapidapi-key", "27a8a51e73mshb56ce7441cf679cp1cc3b1jsn492bbef14582");
            request.Headers.Add("x-rapidapi-host", "covid-19-tracking.p.rapidapi.com");

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStreamAsync();
            var registry = await JsonSerializer.DeserializeAsync<CountryRegistry>(content);

            return registry;
        }
    }
}
