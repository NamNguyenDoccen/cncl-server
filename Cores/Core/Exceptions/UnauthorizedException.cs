using System.Net;

namespace Core.Exceptions;

public class UnauthorizedException : CnclException
{
    public UnauthorizedException(string message) : base(message, [], HttpStatusCode.Unauthorized)
    {
    }

    public UnauthorizedException() : base("Unauthorized", [], HttpStatusCode.Unauthorized)
    {
    }
}