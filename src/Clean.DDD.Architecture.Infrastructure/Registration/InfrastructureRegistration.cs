using System.Diagnostics.CodeAnalysis;
using Clean.DDD.Architecture.Infrastructure.Context;
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

            return services;
        }
    }
}
