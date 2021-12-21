namespace ServerApp.Shared.DTOs.Catalog;

public class UpdatePropertyRequest : IMustBeValid
{
    public string Name { get; set; }
    public string Description { get; set; }
}