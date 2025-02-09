using System.Data;
using Microsoft.EntityFrameworkCore;

namespace Clean.DDD.Architecture.Infrastructure.Extensions
{
    public static class DBContextExtension
    {
        public static async Task<T?> ExecuteScalarAsync<T>(this DbContext context, string rawSql, params object[] parameters)
        {
            var conn = context.Database.GetDbConnection();
            using var command = conn.CreateCommand();
            command.CommandText = rawSql;

            if (parameters != null)
            {
                foreach (var p in parameters)
                {
                    command.Parameters.Add(p);
                }
            }

            if (conn.State == ConnectionState.Closed)
            {
                await context.Database.OpenConnectionAsync();
            }

            var result = await command.ExecuteScalarAsync();

            if (conn.State == ConnectionState.Open)
            {
                await context.Database.CloseConnectionAsync();
            }

            return (T?)Convert.ChangeType(result, typeof(T?));
        }
    }
}
