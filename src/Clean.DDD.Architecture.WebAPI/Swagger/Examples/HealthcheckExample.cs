using System.Diagnostics.CodeAnalysis;
using Swashbuckle.AspNetCore.Filters;

namespace Clean.DDD.Architecture.WebAPI.Swagger.Examples
{
    [ExcludeFromCodeCoverage]
    public class HealthcheckModelExample : IExamplesProvider<string>
    {
        public string GetExamples()
        {
            return DateTime.UtcNow.ToString("dd/MM/yyyy HH:mm:ss.fff");
        }
    }
}
