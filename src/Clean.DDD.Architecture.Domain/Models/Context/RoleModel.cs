using System.Diagnostics.CodeAnalysis;
using Clean.DDD.Architecture.Domain.Models.Base;

namespace Clean.DDD.Architecture.Domain.Models.Context
{
    [ExcludeFromCodeCoverage]
    public class RoleModel : BaseModel
    {
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
    }
}
