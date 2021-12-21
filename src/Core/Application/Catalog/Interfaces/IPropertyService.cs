using ServerApp.Application.Common.Interfaces;
using ServerApp.Application.Wrapper;
using ServerApp.Shared.DTOs.Catalog;

namespace ServerApp.Application.Catalog.Interfaces;

public interface IPropertyService : ITransientService
{
    Task<PaginatedResult<PropertyDto>> SearchAsync(PropertyListFilter filter);
    Task<Result<PropertyDto>> GetPropertyDetailsAsync(Guid id);

    Task<Result<Guid>> CreatePropertyAsync(CreatePropertyRequest request);

    Task<Result<Guid>> UpdatePropertyAsync(UpdatePropertyRequest request, Guid id);

    Task<Result<Guid>> DeletePropertyAsync(Guid id);

}