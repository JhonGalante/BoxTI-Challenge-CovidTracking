using Newtonsoft.Json;
using System;

namespace BoxTI.Challenge.CovidTracking.Models.Entities
{
    public class CountryRegistry : BaseEntity
    {
        public string Name { get; set; }
        public int ActiveCases { get; set; }
        public int NewCases { get; set; }
        public int NewDeaths { get; set; }
        public int TotalCases { get; set; }
        public int TotalDeaths { get; set; }
        public int TotalRecovered { get; set; }
        public DateTime LastUpdate { get; set; }

    }
}
