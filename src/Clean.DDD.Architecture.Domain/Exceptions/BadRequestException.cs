using System.Diagnostics.CodeAnalysis;

namespace Clean.DDD.Architecture.Domain.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class BadRequestException : ApplicationException
    {
        public BadRequestException()
        {
        }

        public BadRequestException(string message) : base(message)
        {
        }

        public BadRequestException(string message, Exception nested) : base(message, nested)
        {
        }
    }
}
