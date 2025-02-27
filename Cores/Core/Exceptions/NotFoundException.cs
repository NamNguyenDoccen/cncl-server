using System.Net;

namespace Core.Exceptions;

public class NotFoundException(string message) : CnclException(message, [], HttpStatusCode.NotFound)
{
}