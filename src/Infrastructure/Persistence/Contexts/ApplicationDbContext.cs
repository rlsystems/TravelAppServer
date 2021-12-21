using ServerApp.Application.Abstractions.Services.Identity;
using ServerApp.Application.Common.Interfaces;
using ServerApp.Application.Multitenancy;
using ServerApp.Domain.Catalog;
using ServerApp.Domain.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace ServerApp.Infrastructure.Persistence.Contexts;

public class ApplicationDbContext : BaseDbContext
{
    private readonly IEventService _eventService;
    private readonly ISerializerService _serializer;
    public IDbConnection Connection => Database.GetDbConnection();
    private readonly ICurrentUser _currentUserService;
    private readonly ITenantService _tenantService;

    public ApplicationDbContext(DbContextOptions options, ITenantService tenantService, ICurrentUser currentUserService, ISerializerService serializer, IEventService eventService)
    : base(options, tenantService, currentUserService, serializer)
    {
        _tenantService = tenantService;
        _currentUserService = currentUserService;
        _serializer = serializer;
        _eventService = eventService;
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Property> Properties { get; set; }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        var currentUserId = _currentUserService.GetUserId();
        foreach (var entry in ChangeTracker.Entries<IAuditableEntity>().ToList()) //for each thing being changed of type Iaudit,
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedBy = currentUserId;
                    entry.Entity.LastModifiedBy = currentUserId;
                    break;

                case EntityState.Modified:
                    entry.Entity.LastModifiedOn = DateTime.UtcNow;
                    entry.Entity.LastModifiedBy = currentUserId;
                    break;

                case EntityState.Deleted:
                    if (entry.Entity is ISoftDelete softDelete) //intercept delete requests, add user/time, forward as modified
                    {
                        softDelete.DeletedBy = currentUserId;
                        softDelete.DeletedOn = DateTime.UtcNow;
                        entry.State = EntityState.Modified; //handle as modify (not delete)
                    }

                    break;
            }
        }

        int results = await base.SaveChangesAsync(cancellationToken); //baseDbContext, adds tenant and audit trails
        if (_eventService == null) return results; 

        //logging business
        var entitiesWithEvents = ChangeTracker.Entries<BaseEntity>()
                                                .Select(e => e.Entity)
                                                .Where(e => e.DomainEvents.Count > 0)
                                                .ToArray();

        foreach (var entity in entitiesWithEvents)
        {
            var events = entity.DomainEvents.ToArray();
            entity.DomainEvents.Clear();
            foreach (var @event in events)
            {
                await _eventService.PublishAsync(@event);
            }
        }

        return results;
    }
}