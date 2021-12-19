using ServerApp.Application.Exceptions;
using System.Net;

namespace ServerApp.Application.Multitenancy;

public class InvalidTenantException : CustomException
{
    public InvalidTenantException(string message)
    : base(message, null, HttpStatusCode.BadRequest)
    {
    }
}