using BoxTI.Challenge.CovidTracking.Models.Entities;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
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
            var client = _clientFactory.CreateClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(covidAPI + name),
                Headers =
                {
                    {"x-rapidapi-host", "covid-19-tracking.p.rapidapi.com"},
                    {"x-rapidapi-key", "bf20ff3edemsh98ec952149547adp19d3a9jsneace2484e7af"}
                },
            };

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                var registry = JObject.Parse(content);
                CountryRegistry cr = new CountryRegistry
                {
                    Name = registry["Country_text"].ToString(),
                    ActiveCases = FormatStringToInt(registry["Active Cases_text"].ToString()),
                    LastUpdate = DateTime.Parse(registry["Last Update"].ToString()),
                    NewCases = FormatStringToInt(registry["New Cases_text"].ToString()),
                    NewDeaths = FormatStringToInt(registry["New Deaths_text"].ToString()),
                    TotalCases = FormatStringToInt(registry["Total Cases_text"].ToString()),
                    TotalRecovered = FormatStringToInt(registry["Total Recovered_text"].ToString()),
                    TotalDeaths = FormatStringToInt(registry["Total Deaths_text"].ToString()),
                };
                return cr;
            }
        }

        private int FormatStringToInt(string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(value.Replace(",", "").Replace("+", ""));
            }
        }
    }
}