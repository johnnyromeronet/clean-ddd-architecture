using System.Diagnostics.CodeAnalysis;

namespace Clean.DDD.Architecture.Domain.Models.Internal
{
    [ExcludeFromCodeCoverage]
    public class PaginationModel
    {
        public int? PageNumber { get; set; } = 0;

        public int? PageSize { get; set; } = 0;

        public int? TotalSize { get; set; } = 0;
    }
}
