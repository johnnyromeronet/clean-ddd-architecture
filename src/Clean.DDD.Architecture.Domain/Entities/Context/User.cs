using System.Diagnostics.CodeAnalysis;
using Clean.DDD.Architecture.Domain.Entities.Base;

namespace Clean.DDD.Architecture.Domain.Entities.Context
{
    [ExcludeFromCodeCoverage]
    public class User : BaseEntity
    {
        public int IdentifierTypeId { get; set; }

        public string Identifier { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string Surname { get; set; } = string.Empty;

        public string? SecondSurname { get; set; }

        public string? PhoneNumber { get; set; }

        public string Email { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;

        public int LanguageId { get; set; }

        public bool IsActive { get; set; }

        public bool IsSystem { get; set; }

        public Language? Language { get; set; }

        public IdentifierType? IdentifierType { get; set; }

        public ICollection<UserRole> UserRole { get; set; } = [];

        public ICollection<UserKey> UserKey { get; set; } = [];
    }
}
