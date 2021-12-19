using ServerApp.Application.Common.Interfaces;
using ServerApp.Application.Wrapper;
using ServerApp.Shared.DTOs.Catalog;

namespace ServerApp.Application.Catalog.Interfaces;

public interface IBrandService : ITransientService
{
    Task<PaginatedResult<BrandDto>> SearchAsync(BrandListFilter filter);
    Task<Result<BrandDto>> GetBrandDetailsAsync(Guid id);

    Task<Result<Guid>> CreateBrandAsync(CreateBrandRequest request);

    Task<Result<Guid>> UpdateBrandAsync(UpdateBrandRequest request, Guid id);

    Task<Result<Guid>> DeleteBrandAsync(Guid id);

    Task<Result<string>> GenerateRandomBrandAsync(GenerateRandomBrandRequest request);

    Task<Result<string>> DeleteRandomBrandAsync();
}