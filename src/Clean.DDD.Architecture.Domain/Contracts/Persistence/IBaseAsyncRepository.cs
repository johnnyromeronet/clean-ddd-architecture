using Clean.DDD.Architecture.Domain.Entities.Base;
using Clean.DDD.Architecture.Domain.Models.Internal;

namespace Clean.DDD.Architecture.Domain.Contracts.Persistence
{
    public interface IBaseAsyncRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync(QueryParamModel queryParams);

        Task<T?> GetByIdAsync(int id, bool? enabled = true);

        Task<ResponseModel> AddAsync(T entity, bool save = true);

        Task<ResponseModel> UpdateAsync(T entity, bool save = true);

        Task<ResponseModel> DeleteAsync(T entity, bool save = true, bool logical = true);

        Task<ResponseModel> RollbackAsync();
    }
}
