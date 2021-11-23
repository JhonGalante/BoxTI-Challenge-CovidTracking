using BoxTI.Challenge.CovidTracking.Data.Context;
using BoxTI.Challenge.CovidTracking.Services.CovidHostedService;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BoxTI.Challenge.CovidTracking.HostedService.BackgroundServices
{
    class TimerSaveRegistriesBackgroundService : BackgroundService
    {
        private readonly ILogger<TimerSaveRegistriesBackgroundService> _logger;
        private readonly IServiceScopeFactory _scopeFactory;

        public TimerSaveRegistriesBackgroundService(ILogger<TimerSaveRegistriesBackgroundService> logger, IServiceScopeFactory scopeFactory)
        {
            _logger = logger;
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                using (var scope = _scopeFactory.CreateScope())
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<MySqlContext>();
                    var covidService = scope.ServiceProvider.GetRequiredService<ICovidHostedService>();

                    _logger.LogInformation("Starting CovidService saveCountriesRegistry job...");
                    await covidService.UpdateCountriesRegistry(dbContext);
                    _logger.LogInformation("CovidService saveCountriesRegistry processed successfully!");

                    await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
                }
            }
            catch(Exception e)
            {
                _logger.LogError($"An error has occurred while processing CovidService saveCountriesRegistry charges. See logs for more details: {e}");
            }
        }
    }
}
