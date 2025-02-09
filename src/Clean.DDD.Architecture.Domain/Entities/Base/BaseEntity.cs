using System.Diagnostics.CodeAnalysis;

namespace Clean.DDD.Architecture.Domain.Entities.Base
{
    [ExcludeFromCodeCoverage]
    public class BaseEntity
    {
        public int Id { get; set; }

        public bool Enabled { get; set; }

        public string IUser { get; set; } = string.Empty;

        public DateTime IDate { get; set; }

        public string IComments { get; set; } = string.Empty;

        public string? UUser { get; set; }

        public DateTime UDate { get; set; }

        public string? UComments { get; set; }
    }
}
