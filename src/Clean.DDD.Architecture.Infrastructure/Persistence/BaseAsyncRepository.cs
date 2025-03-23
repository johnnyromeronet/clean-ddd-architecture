using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Web;
using Clean.DDD.Architecture.Domain.Contracts.Persistence;
using Clean.DDD.Architecture.Domain.Entities.Base;
using Clean.DDD.Architecture.Domain.Enums;
using Clean.DDD.Architecture.Domain.Exceptions;
using Clean.DDD.Architecture.Domain.Extensions;
using Clean.DDD.Architecture.Domain.Models.Internal;
using Clean.DDD.Architecture.Infrastructure.Extensions;
using Clean.DDD.Architecture.Infrastructure.Registration;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Clean.DDD.Architecture.Infrastructure.Persistence
{
    [ExcludeFromCodeCoverage]
    public class BaseAsyncRepository<T>(DbContext context) : IBaseAsyncRepository<T> where T : BaseEntity
    {
        protected readonly DbContext _context = context;

        public async Task<IEnumerable<T>> GetAllAsync(QueryParamModel queryParams)
        {
            var parameters = new List<SqlParameter>();
            int paramIndex = 0;

            var schema = ConfigManager.SchemaDatabase;
            var entities = _context.Model.GetEntityTypes();
            var entityType = entities.First(x => x.ClrType == typeof(T));
            var entityName = entityType.Name.Split(".").LastOrDefault();

            var properties = queryParams.Properties != null && queryParams.Properties.Any() ? string.Join(", ", queryParams.Properties) : "*";
            var sqlSelect = $"SELECT {properties} FROM [{schema}].[{entityName}]";
            var sqlCount = $"SELECT COUNT(1) FROM [{schema}].[{entityName}]";
            var sqlWhere = string.Empty;
            var sqlOrder = string.Empty;
            var sqlRows = string.Empty;

            if (queryParams.Filter != null)
            {
                var filters = queryParams.Filter.Where(x => !string.IsNullOrEmpty(x.PropertyName) && !string.IsNullOrEmpty(x.SearchText) && x.Operator.HasValue);
                foreach (var flt in filters)
                {
                    var exists = entityType.ClrType.GetProperty(flt.PropertyName!, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance) != null;
                    sqlWhere += string.IsNullOrEmpty(sqlWhere) ? "WHERE " : "AND ";

                    if (exists)
                    {
                        if (!flt.PropertyName!.StartsWith('['))
                        {
                            flt.PropertyName = $"[{flt.PropertyName}";
                        }

                        if (!flt.PropertyName!.EndsWith(']'))
                        {
                            flt.PropertyName = $"{flt.PropertyName}]";
                        }
                    }

                    var propertyName = flt.PropertyName!;
                    var searchText = flt.SearchText!;

                    if (!searchText.IsNumeric() && flt.ReplaceText.GetValueOrDefault() && !flt.IsDate.GetValueOrDefault())
                    {
                        searchText = searchText.ReplaceSpecialCharacters();
                        propertyName = propertyName.GetReplaceSpecialCharacters();
                    }
                    else if (flt.IsDate.GetValueOrDefault())
                    {
                        var operators = new List<OperatorEnum>()
                        {
                            OperatorEnum.GreaterThan,
                            OperatorEnum.LessThan,
                            OperatorEnum.GreaterThanOrEquals,
                            OperatorEnum.LessThanOrEquals
                        };

                        var dtAux = HttpUtility.UrlDecode(searchText).Trim().StringToDate("yyyy-MM-dd HH:mm:ss", flt.TimeZone, TimeZoneEnum.UTC);
                        searchText = dtAux.DateToString("yyyy-MM-dd HH:mm:ss");

                        if (operators.Contains(flt.Operator!.Value))
                        {
                            searchText = $"'{searchText}'";
                        }
                    }
                    else
                    {
                        var operators = new List<OperatorEnum>()
                        {
                            OperatorEnum.Equals,
                            OperatorEnum.NotEquals,
                            OperatorEnum.Contains,
                            OperatorEnum.NotContains,
                            OperatorEnum.StartsWith,
                            OperatorEnum.EndsWith
                        };

                        if (operators.Contains(flt.Operator!.Value))
                        {
                            searchText = $"'{searchText}'";
                        }
                    }

                    string paramName = $"@p{paramIndex++}";
                    parameters.Add(new SqlParameter(paramName, searchText));

                    sqlWhere += flt.Operator switch
                    {
                        OperatorEnum.Equals => $"{propertyName} = {paramName}",
                        OperatorEnum.NotEquals => $"{propertyName} <> {paramName}",
                        OperatorEnum.Contains => $"{propertyName} LIKE CONCAT('%', {paramName}, '%')",
                        OperatorEnum.NotContains => $"{propertyName} NOT LIKE CONCAT('%', {paramName}, '%')",
                        OperatorEnum.EndsWith => $"{propertyName} LIKE CONCAT({paramName}, '%')",
                        OperatorEnum.StartsWith => $"{propertyName} LIKE CONCAT('%', {paramName})",
                        OperatorEnum.GreaterThan => $"{flt.PropertyName} > {paramName}",
                        OperatorEnum.LessThan => $"{flt.PropertyName} < {paramName}",
                        OperatorEnum.GreaterThanOrEquals => $"{flt.PropertyName} >= {paramName}",
                        OperatorEnum.LessThanOrEquals => $"{flt.PropertyName} <= {paramName}",
                        OperatorEnum.In => $"{flt.PropertyName} IN ({paramName})",
                        OperatorEnum.NotIn => $"{flt.PropertyName} NOT IN ({paramName})",
                        OperatorEnum.IsNull => $"{flt.PropertyName} IS NULL",
                        OperatorEnum.IsNotNull => $"{flt.PropertyName} IS NOT NULL",
                        _ => throw new BadRequestException("The indicated operation is not defined."),
                    };
                }
            }

            queryParams.Pagination!.TotalSize = await _context.ExecuteScalarAsync<int>($"{sqlCount} {sqlWhere}", parameters);

            if (queryParams.Ordenation != null)
            {
                var ordenation = queryParams.Ordenation.Where(x => !string.IsNullOrEmpty(x.PropertyName));
                foreach (var ord in ordenation)
                {
                    var exists = entityType.ClrType.GetProperty(ord.PropertyName!, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance) != null;
                    sqlOrder += string.IsNullOrEmpty(sqlOrder) ? "ORDER BY " : ", ";

                    if (exists)
                    {
                        if (!ord.PropertyName!.StartsWith('['))
                        {
                            ord.PropertyName = $"[{ord.PropertyName}";
                        }

                        if (!ord.PropertyName!.EndsWith(']'))
                        {
                            ord.PropertyName = $"{ord.PropertyName}]";
                        }
                    }

                    sqlOrder += $"{ord.PropertyName} {(ord.Ascendant.GetValueOrDefault() ? "ASC" : "DESC")}";
                }
            }

            if (string.IsNullOrEmpty(sqlOrder))
            {
                sqlOrder += "ORDER BY 1";
            }

            if (queryParams.Pagination.PageNumber > 0 && queryParams.Pagination.PageSize > 0)
            {
                int skip = (queryParams.Pagination.PageNumber.Value - 1) * queryParams.Pagination.PageSize.Value;
                sqlRows += $"OFFSET {skip} ROWS FETCH NEXT {queryParams.Pagination.PageSize} ROWS ONLY";
            }
            else
            {
                queryParams.Pagination.PageNumber = 1;
                queryParams.Pagination.PageSize = queryParams.Pagination.TotalSize;
            }

            var sqlQuery = $"{sqlSelect} {sqlWhere} {sqlOrder} {sqlRows}";
            return await _context.QuerySqlAsync<T>(sqlQuery, parameters);
        }

        public async Task<T?> GetByIdAsync(int id, bool? enabled = true)
        {
            var dbSet = _context.Set<T>().Where(x => x.Id == id);

            if (enabled.HasValue)
            {
                dbSet = dbSet.Where(x => x.Enabled == enabled.Value);
            }

            return await dbSet.FirstOrDefaultAsync();
        }

        public async Task<ResponseModel> AddAsync(T entity, bool save = true)
        {
            _context.Set<T>().Add(entity);

            if (save)
            {
                await _context.SaveChangesAsync();
            }

            return new()
            {
                Id = entity.Id,
                Message = "The creation was successful.",
                Success = true
            };
        }

        public async Task<ResponseModel> UpdateAsync(T entity, bool save = true)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;

            if (save)
            {
                await _context.SaveChangesAsync();
            }

            return new()
            {
                Id = entity.Id,
                Message = "The update was successful.",
                Success = true
            };
        }

        public async Task<ResponseModel> DeleteAsync(T entity, bool save = true, bool logical = true)
        {
            if (logical)
            {
                entity.Enabled = false;
                await UpdateAsync(entity, false);
            }
            else
            {
                _context.Set<T>().Remove(entity);
            }

            if (save)
            {
                await _context.SaveChangesAsync();
            }

            return new()
            {
                Id = entity.Id,
                Message = "The deletion was successful.",
                Success = true
            };
        }

        public async Task<ResponseModel> RollbackAsync()
        {
            var entries = _context.ChangeTracker.Entries<T>();

            foreach (var entry in entries)
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                    case EntityState.Deleted:
                        entry.State = EntityState.Unchanged;
                        break;

                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                }
            }

            return await Task.FromResult(new ResponseModel()
            {
                Message = "The rollback was successful.",
                Success = true
            });
        }
    }
}
