using AwareTest.Model.Model;
using Microsoft.AspNetCore.DataProtection;

namespace AwareTest.Extensions
{
    public static class ConfigurationExtensions
    {
        public static void ConfigureMyConfig(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<AppSettingsModel>(config.GetSection("AppSettings"));
        }
    }
}
