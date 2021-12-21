namespace ServerApp.Shared.DTOs.Catalog;

public class CreatePropertyRequest : IMustBeValid
{
 
    public string Name { get; set; }
    public string Description { get; set; }



}