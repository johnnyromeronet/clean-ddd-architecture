using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace Clean.DDD.Architecture.Domain.Regex
{
    [ExcludeFromCodeCoverage]
    public partial class RegexPatterns
    {
        [GeneratedRegex(@"\s+")]
        public static partial System.Text.RegularExpressions.Regex ReplaceStringRegex();
    }
}
