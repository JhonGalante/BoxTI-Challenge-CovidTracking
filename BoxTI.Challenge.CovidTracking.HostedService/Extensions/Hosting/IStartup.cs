using Microsoft.Extensions.DependencyInjection;

namespace BoxTI.Challenge.CovidTracking.HostedService.Extensions.Hosting
{
    public interface IStartup
    {
        void ConfigureServices(IServiceCollection services);
    }
}
