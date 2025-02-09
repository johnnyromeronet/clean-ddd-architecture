using System.Diagnostics.CodeAnalysis;
using Clean.DDD.Architecture.Domain.Entities.Base;

namespace Clean.DDD.Architecture.Domain.Entities.Context
{
    [ExcludeFromCodeCoverage]
    public class Role : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public ICollection<UserRole> UserRole { get; set; } = [];
    }
}
