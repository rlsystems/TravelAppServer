using Microsoft.AspNetCore.Mvc;

namespace ServerApp.Host.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
public class BaseController : ControllerBase
{
}