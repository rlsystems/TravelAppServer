using ServerApp.Shared.DTOs.Storage;

namespace ServerApp.Shared.DTOs.Catalog;

public class CreateProductRequest : IMustBeValid
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Rate { get; set; }
    public Guid BrandId { get; set; }
    public FileUploadRequest Image { get; set; }
}