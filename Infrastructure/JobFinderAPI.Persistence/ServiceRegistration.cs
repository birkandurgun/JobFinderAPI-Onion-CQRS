using JobFinderAPI.Application.Interfaces.Repositories;
using JobFinderAPI.Application.Interfaces.UnitOfWorks;
using JobFinderAPI.Persistence.Context;
using JobFinderAPI.Persistence.Interceptors;
using JobFinderAPI.Persistence.Repositories;
using JobFinderAPI.Persistence.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JobFinderAPI.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("SqlServer");

            services.AddScoped<AuditingInterceptor>();
            services.AddDbContext<JobFinderDbContext>((sp, options) => options
                .UseSqlServer(connectionString)
                .AddInterceptors(sp.GetRequiredService<AuditingInterceptor>()));

            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
