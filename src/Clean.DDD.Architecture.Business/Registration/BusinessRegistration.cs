using System.Diagnostics.CodeAnalysis;
using Clean.DDD.Architecture.Business.Services;
using Clean.DDD.Architecture.Domain.Contracts.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Clean.DDD.Architecture.Business.Registration
{
    [ExcludeFromCodeCoverage]
    public static class BusinessRegistration
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IHealthcheckService, HealthcheckService>();
            return services;
        }
    }
}
