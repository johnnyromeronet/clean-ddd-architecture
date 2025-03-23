using System.Data;
using System.Data.Common;
using System.Reflection;
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

        public static async Task<IEnumerable<T>> QuerySqlAsync<T>(this DbContext context, string rawSql, params object[] parameters)
        {
            var conn = context.Database.GetDbConnection();
            using var command = conn.CreateCommand();
            command.CommandText = rawSql;

            if (parameters != null)
                foreach (var p in parameters)
                    command.Parameters.Add(p);

            if (conn.State == ConnectionState.Closed)
                await context.Database.OpenConnectionAsync();

            using var result = await command.ExecuteReaderAsync();
            var data = DataReaderMapToList<T>(result);

            if (conn.State == ConnectionState.Open)
                await context.Database.CloseConnectionAsync();

            return data;
        }

        private static List<T> DataReaderMapToList<T>(DbDataReader dr)
        {
            List<T> list = [];
            var typeName = typeof(T).Name;

            while (dr.Read())
            {
                var obj = Activator.CreateInstance<T>()!;
                foreach (PropertyInfo prop in obj.GetType().GetProperties())
                {
                    if (dr.HasColumn(prop.Name))
                    {
                        if (!object.Equals(dr[prop.Name], DBNull.Value))
                        {
                            prop.SetValue(obj, dr[prop.Name], null);
                        }
                    }
                    else if (dr.HasColumn($"{typeName}{prop.Name}"))
                    {
                        if (!object.Equals(dr[$"{typeName}{prop.Name}"], DBNull.Value))
                        {
                            prop.SetValue(obj, dr[$"{typeName}{prop.Name}"], null);
                        }
                    }
                }
                list.Add(obj);
            }
            return list;
        }

        private static bool HasColumn(this DbDataReader dr, string columnName)
        {
            for (int i = 0; i < dr.FieldCount; i++)
            {
                if (dr.GetName(i).Equals(columnName, StringComparison.InvariantCultureIgnoreCase))
                    return true;
            }
            return false;
        }
    }
}
