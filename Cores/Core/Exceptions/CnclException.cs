using System.Net;

namespace Core.Exceptions;

public class CnclException : Exception
{
    public CnclException(string message, IEnumerable<string> errors, HttpStatusCode statusCode = HttpStatusCode.InternalServerError)
        : base(message)
    {
        ErrorMessages = errors;
        StatusCode = statusCode;
    }

    public CnclException(string message) : base(message)
    {
        ErrorMessages = [];
    }

    public IEnumerable<string> ErrorMessages { get; }
    public HttpStatusCode StatusCode { get; }
}