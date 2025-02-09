using System.Diagnostics.CodeAnalysis;
using Clean.DDD.Architecture.Domain.Entities.Base;

namespace Clean.DDD.Architecture.Domain.Entities.Context
{
    [ExcludeFromCodeCoverage]
    public class Token : BaseEntity
    {
        public string AccessToken { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public DateTime ExpiredDate { get; set; }

        public bool IsRefreshToken { get; set; }
    }
}
