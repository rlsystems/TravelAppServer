namespace ServerApp.Application.Common.Interfaces;

public interface IEmailTemplateService : ITransientService
{
    string GenerateEmailConfirmationMail(string userName, string email, string emailVerificationUri);
}