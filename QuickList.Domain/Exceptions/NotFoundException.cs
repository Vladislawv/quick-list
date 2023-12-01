using System.Net;

namespace QuickList.Domain.Exceptions;

public class NotFoundException : QuickListException
{
    public override HttpStatusCode StatusCode => HttpStatusCode.NotFound;
    
    public NotFoundException(string message) : base(message)
    {
    }
}