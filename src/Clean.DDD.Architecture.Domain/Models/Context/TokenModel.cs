using System.Diagnostics.CodeAnalysis;
using Clean.DDD.Architecture.Domain.Models.Base;

namespace Clean.DDD.Architecture.Domain.Models.Context
{
    [ExcludeFromCodeCoverage]
    public class TokenModel : BaseModel
    {
        public string AccessToken { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string ExpiredDate { get; set; } = string.Empty;

        public bool IsRefreshToken { get; set; }
    }
}
