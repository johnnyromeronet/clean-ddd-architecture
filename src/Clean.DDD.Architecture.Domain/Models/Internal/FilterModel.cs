using System.Diagnostics.CodeAnalysis;
using Clean.DDD.Architecture.Domain.Enums;

namespace Clean.DDD.Architecture.Domain.Models.Internal
{
    [ExcludeFromCodeCoverage]
    public class FilterModel
    {
        public string? PropertyName { get; set; } = null;

        public string? SearchText { get; set; } = null;

        public bool? ReplaceText { get; set; } = false;

        public bool? IsDate { get; set; } = false;

        public string? TimeZone { get; set; } = TimeZoneEnum.UTC;

        public OperatorEnum? Operator { get; set; } = OperatorEnum.None;
    }
}
