using BoxTI.Challenge.CovidTracking.HostedService.BackgroundServices;
using BoxTI.Challenge.CovidTracking.HostedService.Extensions.Hosting;
using FluentAssertions.Common;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text;

namespace BoxTI.Challenge.CovidTracking.HostedService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.UseStartup<Startup>(hostContext.Configuration);
                    services.AddHostedService<TimerSaveRegistriesBackgroundService>();
                });
    }
}
