using System.Diagnostics.CodeAnalysis;
using Clean.DDD.Architecture.Domain.Models.Base;
using Clean.DDD.Architecture.Domain.Models.Internal;
using MediatR;

namespace Clean.DDD.Architecture.Application.Features.BaseAsync.Commands
{
    [ExcludeFromCodeCoverage]
    public class RollbackCommand<T>() : IRequest<ResponseModel> where T : BaseModel
    {
    }
}
