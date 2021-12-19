using ServerApp.Domain.Common.Contracts;

namespace ServerApp.Application.Common.Interfaces;

public interface IEventService : ITransientService
{
    Task PublishAsync(DomainEvent domainEvent);
}