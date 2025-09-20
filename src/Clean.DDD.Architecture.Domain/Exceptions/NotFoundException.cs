using System.Diagnostics.CodeAnalysis;

namespace Clean.DDD.Architecture.Domain.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class NotFoundException : ApplicationException
    {
        public NotFoundException()
        {
        }

        public NotFoundException(string message) : base(message)
        {
        }

        public NotFoundException(string message, Exception nested) : base(message, nested)
        {
        }
    }
}
