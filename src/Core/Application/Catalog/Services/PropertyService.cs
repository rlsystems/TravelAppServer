using ServerApp.Application.Catalog.Interfaces;
using ServerApp.Application.Common.Interfaces;
using ServerApp.Application.Exceptions;
using ServerApp.Application.Wrapper;
using ServerApp.Domain.Catalog;
using ServerApp.Domain.Dashboard;
using ServerApp.Shared.DTOs.Catalog;
using Microsoft.Extensions.Localization;
using ServerApp.Application.Specifications;

namespace ServerApp.Application.Catalog.Services;

public class PropertyService : IPropertyService
{
    private readonly IRepositoryAsync _repository;
    private readonly IJobService _jobService;

    public PropertyService(IRepositoryAsync repository, IJobService jobService)
    {
        _repository = repository;
        _jobService = jobService;
    }

    public async Task<PaginatedResult<PropertyDto>> SearchAsync(PropertyListFilter filter)
    {
        return await _repository.GetSearchResultsAsync<Property, PropertyDto>(filter.PageNumber, filter.PageSize, filter.OrderBy, filter.AdvancedSearch, filter.Keyword);
    }


    public async Task<Result<PropertyDto>> GetPropertyDetailsAsync(Guid id)
    {
        var spec = new BaseSpecification<Property>();
        var property = await _repository.GetByIdAsync<Property, PropertyDto>(id, spec);
        return await Result<PropertyDto>.SuccessAsync(property);
    }

    public async Task<Result<Guid>> CreatePropertyAsync(CreatePropertyRequest request)
    {
        bool propertyExists = await _repository.ExistsAsync<Property>(a => a.Name == request.Name);
        if (propertyExists) throw new EntityAlreadyExistsException("property already exists");



        var property = new Property(request.Name, request.Description);
        //property.DomainEvents.Add(new StatsChangedEvent());

        var propertyId = await _repository.CreateAsync<Property>(property);

        await _repository.SaveChangesAsync();
        return await Result<Guid>.SuccessAsync(propertyId);
    }

    public async Task<Result<Guid>> UpdatePropertyAsync(UpdatePropertyRequest request, Guid id)
    {
        var property = await _repository.GetByIdAsync<Property>(id); //this will call the simplistic get by Id (not map to DTO) method in repository
        if (property == null) throw new EntityNotFoundException("property not found");

        var updatedProperty = property.Update(request.Name, request.Description);

        //updatedProperty.DomainEvents.Add(new StatsChangedEvent());

        await _repository.UpdateAsync<Property>(updatedProperty); //sets current values, removes cache key, returns task complete
        await _repository.SaveChangesAsync();
        return await Result<Guid>.SuccessAsync(id);
    }

    public async Task<Result<Guid>> DeletePropertyAsync(Guid id)
    {
        var PropertyToDelete = await _repository.RemoveByIdAsync<Property>(id);
        //PropertyToDelete.DomainEvents.Add(new StatsChangedEvent());
        await _repository.SaveChangesAsync();
        return await Result<Guid>.SuccessAsync(id);
    }


}