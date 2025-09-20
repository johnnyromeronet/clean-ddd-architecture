using System.Diagnostics.CodeAnalysis;

namespace Clean.DDD.Architecture.Domain.Models.Internal
{
    [ExcludeFromCodeCoverage]
    public class AuditModel
    {
        public string IUser { get; set; } = string.Empty;

        public DateTime IDate { get; set; }

        public string IComments { get; set; } = string.Empty;

        public string? UUser { get; set; }

        public DateTime UDate { get; set; }

        public string? UComments { get; set; }
    }
}
