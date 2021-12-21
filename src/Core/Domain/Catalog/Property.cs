using ServerApp.Domain.Common;
using ServerApp.Domain.Common.Contracts;
using ServerApp.Domain.Contracts;

namespace ServerApp.Domain.Catalog;

public class Property : AuditableEntity, IMustHaveTenant
{
    // public enum ReservationStyles {
    //     ScheduledItinerary = 1,
    //     OpenItinerary = 2,
    //     Nightly = 3
    // }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public string Tenant { get; set; }


    public Property(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public Property Update(string name, string description)
    {
        if (name != null && !Name.NullToString().Equals(name)) Name = name;
        Description = description;
        return this;
    }
}