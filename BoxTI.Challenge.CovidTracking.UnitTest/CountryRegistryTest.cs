using BoxTI.Challenge.CovidTracking.Services.Services;
using Newtonsoft.Json.Linq;
using NSubstitute;
using System;
using System.Threading.Tasks;
using Xunit;

namespace BoxTI.Challenge.CovidTracking.UnitTest
{
    public class CountryRegistryTest
    {
        [Fact(DisplayName = "Get Country Registries from API with Success")]
        public void GetCountryRegistry_Success()
        {
            var covidService = Substitute.For<ICovidService>();

            covidService.getCountryCovidRegistry().Returns(new JArray { });
            covidService.Received(1);
        }
    }
}
