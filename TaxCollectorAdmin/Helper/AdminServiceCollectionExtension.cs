using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaxCollectorAdmin.Services;

namespace TaxCollectorAdmin.Helper
{
    public static class AdminServiceCollectionExtension
    {
        public static IServiceCollection AddHttpConfiguration(this IServiceCollection services, IConfiguration config)
        {
            services.AddHttpClient<ITAPSAdmin, TAPSAdmin>();

            return services;
        }
    }
}
