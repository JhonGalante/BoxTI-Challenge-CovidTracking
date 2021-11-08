using BoxTI.Challenge.CovidTracking.Data.Context;
using BoxTI.Challenge.CovidTracking.Data.Dapper;
using BoxTI.Challenge.CovidTracking.Models.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxTI.Challenge.CovidTracking.Data.Repository
{
    public class CountryRegistryRepository : ICountryRegistryRepository
    {
        private readonly MySqlContext _context;
        private readonly DbSession _db;

        public CountryRegistryRepository(MySqlContext context, DbSession db)
        {
            _context = context;
            _db = db;
        }


        public CountryRegistry GetByName(string name)
        {
            return _context.CountryRegistries.Where(c => c.Name == name).FirstOrDefault();
        }

        public async Task<IList<dynamic>> GetOrderedByActiveCases()
        {
            using(var conn = _db.Connection)
            {
                string query = @"SELECT *,((LAG (ActiveCases) OVER (ORDER BY ActiveCases DESC) - ActiveCases) / ActiveCases) * 100 AS DifferenceActiveCasesPreviousPercent
                                FROM countrycovidregistry 
                                WHERE Name != 'World'
                                ORDER BY ActiveCases DESC;";

                var registries = (await conn.QueryAsync(sql: query)).ToList();
                return registries;
            }

        }
    }
}
