using System.Diagnostics.CodeAnalysis;
using Clean.DDD.Architecture.Domain.Contracts.Persistence;
using Clean.DDD.Architecture.Infrastructure.Context;
using Clean.DDD.Architecture.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Clean.DDD.Architecture.Infrastructure.Registration
{
    [ExcludeFromCodeCoverage]
    public static class InfrastructureRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration config)
        {
            ConfigManager.Config = config;
            services.AddDbContext<CurrentDBContext>(options => options.UseSqlServer(ConfigManager.CurrentDatabase));

            services.AddScoped(typeof(IBaseAsyncRepository<>), typeof(BaseAsyncRepository<>));

            return services;
        }
    }
}
