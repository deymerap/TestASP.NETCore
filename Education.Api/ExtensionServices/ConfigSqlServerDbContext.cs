using Education.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Education.Api.ExtensionServices
{
    public static class ConfigSqlServerDbContext
    {
        public static void ConfigureSqlServerDbContext(this IServiceCollection services, IConfiguration configuration, ILoggerFactory loggerFactory = null)
        {
            services.AddDbContextPool<EducatioDBContext>(cfg =>
            {
                cfg.UseSqlServer(configuration["ConnectionStrings:Default"])
                .EnableSensitiveDataLogging(true)
                .UseLoggerFactory(loggerFactory);
            });
        }

    }
}
