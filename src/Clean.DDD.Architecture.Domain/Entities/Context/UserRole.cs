using System.Diagnostics.CodeAnalysis;
using Clean.DDD.Architecture.Domain.Entities.Base;

namespace Clean.DDD.Architecture.Domain.Entities.Context
{
    [ExcludeFromCodeCoverage]
    public class UserRole : BaseEntity
    {
        public int UserId { get; set; }

        public int RoleId { get; set; }

        public User? User { get; set; }

        public Role? Role { get; set; }
    }
}
