namespace ServerApp.Shared.DTOs.Notifications;

public interface INotificationMessage
{
    public string MessageType { get; set; }

    public string Message { get; set; }
}