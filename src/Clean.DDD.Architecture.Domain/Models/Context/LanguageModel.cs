using System.Diagnostics.CodeAnalysis;
using Clean.DDD.Architecture.Domain.Models.Base;

namespace Clean.DDD.Architecture.Domain.Models.Context
{
    [ExcludeFromCodeCoverage]
    public class LanguageModel : BaseModel
    {
        public string Code { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
    }
}
