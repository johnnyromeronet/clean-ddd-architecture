using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;

namespace Clean.DDD.Architecture.Application.Registration
{
    [ExcludeFromCodeCoverage]
    public static class ApplicationRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            return services;
        }
    }
}
