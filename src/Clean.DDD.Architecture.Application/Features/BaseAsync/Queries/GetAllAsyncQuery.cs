using System.Diagnostics.CodeAnalysis;
using Clean.DDD.Architecture.Domain.Models.Base;
using Clean.DDD.Architecture.Domain.Models.Internal;
using MediatR;

namespace Clean.DDD.Architecture.Application.Features.BaseAsync.Queries
{
    [ExcludeFromCodeCoverage]
    public class GetAllAsyncQuery<T>(QueryParamModel queryParams) : IRequest<IEnumerable<T>> where T : BaseModel
    {
        public QueryParamModel QueryParams { get; set; } = queryParams;
    }
}
