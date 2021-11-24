using System;
using System.Collections.Generic;
using System.Text;

namespace BoxTI.Challenge.CovidTracking.API.Models.Models
{
    public class CountryRegistryResult
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
