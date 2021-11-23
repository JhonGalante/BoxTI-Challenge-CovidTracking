using BoxTI.Challenge.CovidTracking.Data.Context;
using BoxTI.Challenge.CovidTracking.Data.Dapper;
using BoxTI.Challenge.CovidTracking.Data.Repository;
using BoxTI.Challenge.CovidTracking.HostedService.Extensions.Hosting;
using BoxTI.Challenge.CovidTracking.Models.Entities;
using BoxTI.Challenge.CovidTracking.Services.CovidHostedService;
using BoxTI.Challenge.CovidTracking.Services.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoxTI.Challenge.CovidTracking.HostedService
{
    public class Startup : IStartup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public virtual void ConfigureServices(IServiceCollection services)
        {
            if(services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddHttpClient();

            services.AddTransient<MySqlContext>();

            //services.AddTransient<IBaseService<CountryRegistry>, BaseService<CountryRegistry>>();
            services.AddTransient<ICovidHostedService, CovidHostedService>();

            //services.AddTransient<IBaseRepository<CountryRegistry>, BaseRepository<CountryRegistry>>();
            //services.AddTransient<ICountryRegistryRepository, CountryRegistryRepository>();

            services.AddTransient<DbSession>();
        }
    }
}
