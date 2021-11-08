using BoxTI.Challenge.CovidTracking.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BoxTI.Challenge.CovidTracking.Services.CountryRegistryService
{
    public interface ICountryRegistryService
    {
        IEnumerable<CountryRegistry> getOrderedByActiveCases();
    }
}
