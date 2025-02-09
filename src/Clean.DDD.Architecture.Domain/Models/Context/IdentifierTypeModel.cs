using System.Diagnostics.CodeAnalysis;
using Clean.DDD.Architecture.Domain.Models.Base;

namespace Clean.DDD.Architecture.Domain.Models.Context
{
    [ExcludeFromCodeCoverage]
    public class IdentifierTypeModel : BaseModel
    {
        public string Description { get; set; } = string.Empty;
    }
}
