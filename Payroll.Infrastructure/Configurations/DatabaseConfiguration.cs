using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Payroll.Infrastructure.Configurations
{
    public static class DatabaseConfiguration
    {
        public static IServiceCollection AddDatabaseConfiguration(this IServiceCollection services)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            var connectionString = Environment.GetEnvironmentVariable("SQL_CONNECTION");
            if (string.IsNullOrEmpty(connectionString))
                throw new Exception("Sql Connection is required");

            services.AddDbContext<IdentityDbContext>(options =>
                options.UseNpgsql(connectionString));

            return services;
        }
    }
}
