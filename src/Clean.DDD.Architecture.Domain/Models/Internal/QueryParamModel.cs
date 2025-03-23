using System.Diagnostics.CodeAnalysis;

namespace Clean.DDD.Architecture.Domain.Models.Internal
{
    [ExcludeFromCodeCoverage]
    public class QueryParamModel
    {
        public PaginationModel? Pagination { get; set; } = new();

        public IEnumerable<OrdenationModel>? Ordenation { get; set; } = [];

        public IEnumerable<FilterModel>? Filter { get; set; } = [];

        public IEnumerable<string>? Properties { get; set; } = [];
    }
}
