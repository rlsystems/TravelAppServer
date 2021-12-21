namespace ServerApp.Shared.DTOs.Catalog;

public class PropertyDto : IDto
{

    // public enum ReservationStyles
    // {
    //     ScheduledItinerary,
    //     OpenItinerary,
    //     Nightly
    // }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

   // public ReservationStyles ReservationStyle { get; set; }


}