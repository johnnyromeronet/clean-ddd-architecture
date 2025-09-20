using System.Diagnostics.CodeAnalysis;
using Clean.DDD.Architecture.Domain.Models.Base;
using Clean.DDD.Architecture.Domain.Models.Internal;
using MediatR;

namespace Clean.DDD.Architecture.Application.Features.BaseAsync.Commands
{
    [ExcludeFromCodeCoverage]
    public class DeleteAsyncCommand<T>(int id, AuditModel audit, bool save = true, bool logical = true) : IRequest<ResponseModel> where T : BaseModel
    {
        public int Id { get; set; } = id;

        public AuditModel Audit { get; set; } = audit;

        public bool Save { get; set; } = save;

        public bool Logical { get; set; } = logical;
    }
}
