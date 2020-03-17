using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using TaxCollectorAdmin.Models;

namespace TaxCollectorAdmin.Helper
{
    public static class ConfigurationServiceCollectionExtension
    {
        public static IServiceCollection AddAppConfiguration(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<AppConstants>(config.GetSection("APPCONSTANTS"));

            services.TryAddSingleton<IAppConstants>(sp =>
                sp.GetRequiredService<IOptions<AppConstants>>().Value); 


            return services;
        }
    }
}
