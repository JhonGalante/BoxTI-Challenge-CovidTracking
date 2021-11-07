using BoxTI.Challenge.CovidTracking.Data.Context;
using BoxTI.Challenge.CovidTracking.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoxTI.Challenge.CovidTracking.Data.Repository
{
    public class CountryRegistryRepository : ICountryRegistryRepository
    {
        private readonly MySqlContext _context;

        public CountryRegistryRepository(MySqlContext context)
        {
            _context = context;
        }


        public CountryRegistry GetByName(string name)
        {
            return _context.CountryRegistries.Where(c => c.Name == name).FirstOrDefault();
        }
    }
}
