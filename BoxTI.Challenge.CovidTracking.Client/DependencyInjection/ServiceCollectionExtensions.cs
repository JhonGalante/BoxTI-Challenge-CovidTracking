using BoxTI.Challenge.CovidTracking.Client.Implementation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoxTI.Challenge.CovidTracking.Client.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMicroserviceApiClient(this IServiceCollection services)
        {
            if(services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddHttpClient<IMicroserviceAPIClient, MicroserviceAPIClient>();

            return services;
        }
    }
}
