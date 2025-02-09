using System.Diagnostics.CodeAnalysis;
using Clean.DDD.Architecture.Domain.Entities.Base;

namespace Clean.DDD.Architecture.Domain.Entities.Context
{
    [ExcludeFromCodeCoverage]
    public class IdentifierType : BaseEntity
    {
        public string Description { get; set; } = string.Empty;
    }
}
