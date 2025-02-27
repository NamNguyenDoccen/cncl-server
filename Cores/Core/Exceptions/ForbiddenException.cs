using System.Net;

namespace Core.Exceptions;

public class ForbiddenException : CnclException
{
    public ForbiddenException(string message) : base(message, [], HttpStatusCode.Forbidden)
    {
    }

    public ForbiddenException() : base("Forbidden", [], HttpStatusCode.Forbidden)
    {
    }
}