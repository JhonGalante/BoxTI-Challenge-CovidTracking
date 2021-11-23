using BoxTI.Challenge.CovidTracking.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BoxTI.Challenge.CovidTracking.Services.CovidHostedService
{
    public class CovidHostedService : ICovidHostedService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly string covidAPI;
        private readonly List<string> countries;

        public CovidHostedService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            covidAPI = "https://covid-19-tracking.p.rapidapi.com/v1";
            countries = new List<string> { "Brazil", "Japan", "Netherlands", "Nigeria", "Australia", "World" };
        }

        public async Task<JArray> getCountryCovidRegistry()
        {
            var client = _clientFactory.CreateClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(covidAPI),
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
                var registry = JsonConvert.DeserializeObject<JArray>(content);
                return registry;
            }
        }

        public async Task<string> UpdateCountriesRegistry(DbContext context)
        {
            var count = 0;
            var registries = await getCountryCovidRegistry();

            foreach (var country in countries)
            {
                var registry = registries.SelectToken($"[?(@.Country_text == '{country}')]");

                if (context.Set<CountryRegistry>().FindAsync(registry["Country_text"].ToString()) == null)
                {
                    context.Set<CountryRegistry>().Update(
                        new CountryRegistry
                        {
                            Name = registry["Country_text"].ToString(),
                            ActiveCases = FormatStringToInt(registry["Active Cases_text"].ToString()),
                            LastUpdate = DateTime.Parse(registry["Last Update"].ToString()),
                            NewCases = FormatStringToInt(registry["New Cases_text"].ToString()),
                            NewDeaths = FormatStringToInt(registry["New Deaths_text"].ToString()),
                            TotalCases = FormatStringToInt(registry["Total Cases_text"].ToString()),
                            TotalRecovered = FormatStringToInt(registry["Total Recovered_text"].ToString()),
                            TotalDeaths = FormatStringToInt(registry["Total Deaths_text"].ToString()),
                        }
                    );

                    context.SaveChanges();

                    count++;
                }

            }
            return $"{count} registros foram salvos no banco";
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
