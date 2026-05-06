using Payroll.Core.Interfaces.Repositories;
using Payroll.Core.Interfaces.Services;
using Payroll.Core.Services;
using Payroll.Infrastructure.Repositories;

namespace Payroll.Api.Configurations
{
    public static class ServicesConfiguration
    {

        public static IServiceCollection AddServicesConfiguration(this IServiceCollection services)
        {
            //Services
            services.AddScoped<ICsvService, CsvService>();
            services.AddScoped<IOvertimeService, OvertimeService>();


            //Repositories
            services.AddScoped<IOvertimeRecordRepository, OvertimeRecordRepository>();
            services.AddScoped<IOvertimeErrorRepository, OvertimeErrorRepository>();
            services.AddScoped<IProcessedFileRepository, ProcessedFileRepository>();

            return services;
        }
    }
}
