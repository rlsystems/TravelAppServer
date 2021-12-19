using ServerApp.Application.Common.Event;
using ServerApp.Application.Common.Interfaces;
using ServerApp.Domain.Dashboard;
using ServerApp.Shared.DTOs.Notifications;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ServerApp.Application.Dashboard;

public class StatsChangedEventHandler : INotificationHandler<EventNotification<StatsChangedEvent>>
{
    private readonly ILogger<StatsChangedEventHandler> _logger;
    private readonly INotificationService _notificationService;

    public StatsChangedEventHandler(ILogger<StatsChangedEventHandler> logger, INotificationService notificationService)
    {
        _logger = logger;
        _notificationService = notificationService;
    }

    public async Task Handle(EventNotification<StatsChangedEvent> notification, CancellationToken cancellationToken)
    {
        await _notificationService.SendMessageAsync(new StatsChangedNotification());
        _logger.LogInformation("{event} Triggered", notification.DomainEvent.GetType().Name);
    }
}