using System.Diagnostics.CodeAnalysis;
using Clean.DDD.Architecture.Domain.Models.Base;
using Clean.DDD.Architecture.Domain.Models.Internal;
using MediatR;

namespace Clean.DDD.Architecture.Application.Features.BaseAsync.Commands
{
    [ExcludeFromCodeCoverage]
    public class UpdateAsyncCommand<T>(int id, T model, AuditModel audit, bool save = true) : IRequest<ResponseModel> where T : BaseModel
    {
        public int Id { get; set; } = id;

        public T Model { get; set; } = model;

        public AuditModel Audit { get; set; } = audit;

        public bool Save { get; set; } = save;
    }
}
