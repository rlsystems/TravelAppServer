using System.Net;

namespace ServerApp.Application.Exceptions;

public class EntityNotFoundException : CustomException
{
    public EntityNotFoundException(string message)
    : base(message, null, HttpStatusCode.NotFound)
    {
    }
}