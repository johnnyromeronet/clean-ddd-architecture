using Clean.DDD.Architecture.Domain.Contracts.Services;
using Clean.DDD.Architecture.Infrastructure.Context;
using Clean.DDD.Architecture.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Clean.DDD.Architecture.Business.Services
{
    public class HealthcheckService : IHealthcheckService
    {
        public async Task<string> GetDatabaseStatus()
        {
            using DbContext context = new CurrentDBContext(new DbContextOptions<CurrentDBContext>());
            var rawSql = "SELECT GETDATE()";
            var response = await DBContextExtension.ExecuteScalarAsync<DateTime>(context, rawSql, []);
            return response.ToString("dd/MM/yyyy HH:mm:ss.fff");
        }
    }
}
