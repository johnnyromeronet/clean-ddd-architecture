using System.Diagnostics.CodeAnalysis;
using Clean.DDD.Architecture.Domain.Models.Base;
using MediatR;

namespace Clean.DDD.Architecture.Application.Features.BaseAsync.Queries
{
    [ExcludeFromCodeCoverage]
    public class GetByIdAsyncQuery<T>(int id, bool? enabled = true) : IRequest<T> where T : BaseModel
    {
        public int Id { get; set; } = id;

        public bool? Enabled { get; set; } = enabled;
    }
}
