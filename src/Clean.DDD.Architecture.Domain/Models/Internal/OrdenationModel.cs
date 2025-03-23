using System.Diagnostics.CodeAnalysis;

namespace Clean.DDD.Architecture.Domain.Models.Internal
{
    [ExcludeFromCodeCoverage]
    public class OrdenationModel
    {
        public string? PropertyName { get; set; } = null;

        public bool? Ascendant { get; set; } = true;
    }
}
