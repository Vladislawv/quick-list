using System.Net;

namespace QuickList.Domain.Exceptions;

public abstract class QuickListException : Exception
{
    public abstract HttpStatusCode StatusCode { get; }

    protected QuickListException(string message) : base(message)
    {
    }
}