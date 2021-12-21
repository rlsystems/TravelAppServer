using ServerApp.Application.Catalog.Interfaces;
using ServerApp.Domain.Constants;
using ServerApp.Infrastructure.Identity.Permissions;
using ServerApp.Shared.DTOs.Catalog;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ServerApp.Host.Controllers.Catalog;

public class PropertiesController : BaseController
{
    private readonly IPropertyService _service;

    public PropertiesController(IPropertyService service)
    {
        _service = service;
    }

    [HttpPost("search")]
    //[MustHavePermission(PermissionConstants.Properties.Search)]
    [SwaggerOperation(Summary = "Search Properties using available Filters.")]
    public async Task<IActionResult> SearchAsync(PropertyListFilter filter)
    {
        var properties = await _service.SearchAsync(filter);
        return Ok(properties);
    }

    [HttpGet("{id}")]
    //[MustHavePermission(PermissionConstants.Properties.View)]
    public async Task<IActionResult> GetAsync(Guid id)
    {
        var property = await _service.GetPropertyDetailsAsync(id);
        return Ok(property);
    }



    [HttpPost]
    //[MustHavePermission(PermissionConstants.Properties.Register)]
    public async Task<IActionResult> CreateAsync(CreatePropertyRequest request)
    {
        return Ok(await _service.CreatePropertyAsync(request));
    }

    [HttpPut("{id}")]
    //[MustHavePermission(PermissionConstants.Properties.Update)]
    public async Task<IActionResult> UpdateAsync(UpdatePropertyRequest request, Guid id)
    {
        return Ok(await _service.UpdatePropertyAsync(request, id));
    }

    [HttpDelete("{id}")]
    //[MustHavePermission(PermissionConstants.Properties.Remove)]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        var propertyId = await _service.DeletePropertyAsync(id);
        return Ok(propertyId);
    }

}