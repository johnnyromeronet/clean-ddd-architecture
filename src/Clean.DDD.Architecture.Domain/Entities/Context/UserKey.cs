using System.Diagnostics.CodeAnalysis;
using Clean.DDD.Architecture.Domain.Entities.Base;

namespace Clean.DDD.Architecture.Domain.Entities.Context
{
    [ExcludeFromCodeCoverage]
    public class UserKey : BaseEntity
    {
        public int UserId { get; set; }

        public string PasswordHash { get; set; } = string.Empty;

        public User? User { get; set; }
    }
}
