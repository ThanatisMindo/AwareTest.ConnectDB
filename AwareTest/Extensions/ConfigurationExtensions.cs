using AwareTest.ModelNew.Model;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace AwareTest.Extensions
{
    public static class ConfigurationExtensions
    {
        public static void ConfigureMyConfig(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<AppSettingsModel>(config.GetSection("AppSettings"));
        }

        public static void ConfigureService(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<AppSettingsModel>(config.GetSection("AppSettings"));
        }
        public static void ConfigureSQLContext(this DbContextOptionsBuilder options, IConfiguration config)
        {
            options.UseSqlServer(config.GetConnectionString("Database"));
        }
    }
}
