using System.Diagnostics.CodeAnalysis;

namespace Clean.DDD.Architecture.Domain.Models.Internal
{
    [ExcludeFromCodeCoverage]
    public class ResponseModel
    {
        public int Id { get; set; }

        public string? Message { get; set; }

        public bool Success { get; set; }
    }
}
