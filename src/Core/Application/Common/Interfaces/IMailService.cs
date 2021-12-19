using ServerApp.Shared.DTOs.General.Requests;

namespace ServerApp.Application.Common.Interfaces;

public interface IMailService : ITransientService
{
    Task SendAsync(MailRequest request);
}