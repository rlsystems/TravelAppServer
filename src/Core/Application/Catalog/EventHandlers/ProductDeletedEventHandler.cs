using ServerApp.Application.Common.Event;
using ServerApp.Domain.Catalog.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ServerApp.Application.Catalog.EventHandlers;

public class ProductDeletedEventHandler : INotificationHandler<EventNotification<ProductDeletedEvent>>
{
    private readonly ILogger<ProductDeletedEventHandler> _logger;

    public ProductDeletedEventHandler(ILogger<ProductDeletedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(EventNotification<ProductDeletedEvent> notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("{event} Triggered", notification.DomainEvent.GetType().Name);
        return Task.CompletedTask;
    }
}