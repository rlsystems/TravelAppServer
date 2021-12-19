using ServerApp.Application.Common.Interfaces;
using ServerApp.Application.Wrapper;
using ServerApp.Shared.DTOs.Catalog;

namespace ServerApp.Application.Catalog.Interfaces;

public interface IProductService : ITransientService
{
    Task<Result<ProductDetailsDto>> GetProductDetailsAsync(Guid id);

    Task<Result<ProductDto>> GetByIdUsingDapperAsync(Guid id);

    Task<PaginatedResult<ProductDto>> SearchAsync(ProductListFilter filter);

    Task<Result<Guid>> CreateProductAsync(CreateProductRequest request);

    Task<Result<Guid>> UpdateProductAsync(UpdateProductRequest request, Guid id);

    Task<Result<Guid>> DeleteProductAsync(Guid id);
}