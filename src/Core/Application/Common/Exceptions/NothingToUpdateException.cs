using System.Net;

namespace ServerApp.Application.Exceptions;

public class NothingToUpdateException : CustomException
{
    public NothingToUpdateException()
    : base("There are no new changes to update for this Entity.", null, HttpStatusCode.NotAcceptable)
    {
    }
}