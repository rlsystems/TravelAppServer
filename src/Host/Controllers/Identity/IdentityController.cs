using ServerApp.Application.Abstractions.Services.Identity;
using ServerApp.Domain.Constants;
using ServerApp.Infrastructure.Identity.Permissions;
using ServerApp.Shared.DTOs.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ServerApp.Host.Controllers.Identity;

[ApiController]
[Route("api/[controller]")]
public sealed class IdentityController : ControllerBase
{
    private readonly ICurrentUser _user;
    private readonly IIdentityService _identityService;
    private readonly IUserService _userService;

    public IdentityController(IIdentityService identityService, ICurrentUser user, IUserService userService)
    {
        _identityService = identityService;
        _user = user;
        _userService = userService;
    }

    [HttpPost("register")]
    [MustHavePermission(PermissionConstants.Identity.Register)]
    public async Task<IActionResult> RegisterAsync(RegisterRequest request)
    {
        string origin = GenerateOrigin();
        return Ok(await _identityService.RegisterAsync(request, origin));
    }

    [HttpGet("confirm-email")]
    [AllowAnonymous]
    public async Task<IActionResult> ConfirmEmailAsync([FromQuery] string userId, [FromQuery] string code, [FromQuery] string tenant)
    {
        return Ok(await _identityService.ConfirmEmailAsync(userId, code, tenant));
    }

    [HttpGet("confirm-phone-number")]
    [AllowAnonymous]
    public async Task<IActionResult> ConfirmPhoneNumberAsync([FromQuery] string userId, [FromQuery] string code)
    {
        return Ok(await _identityService.ConfirmPhoneNumberAsync(userId, code));
    }

    [HttpPost("forgot-password")]
    [AllowAnonymous]
    public async Task<IActionResult> ForgotPasswordAsync(ForgotPasswordRequest request)
    {
        string origin = GenerateOrigin();
        return Ok(await _identityService.ForgotPasswordAsync(request, origin));
    }

    [HttpPost("reset-password")]
    [AllowAnonymous]
    public async Task<IActionResult> ResetPasswordAsync(ResetPasswordRequest request)
    {
        return Ok(await _identityService.ResetPasswordAsync(request));
    }

    [HttpGet("profile")] //get your own profile (basic user permissions)
    public async Task<IActionResult> GetProfileDetailsAsync()
    {
        return Ok(await _userService.GetAsync(_user.GetUserId().ToString()));
    }

    [HttpPut("profile")] //Update your own profile (basic user permissions)
    public async Task<IActionResult> UpdateProfileAsync(UpdateProfileRequest request)
    {
        return Ok(await _identityService.UpdateProfileAsync(request, _user.GetUserId().ToString()));
    }

    [HttpGet("profile/{id}")] //ADMIN Get a profile
    //Permissions Here
    public async Task<IActionResult> GetProfileDetailsAsync(Guid id)
    {
        return Ok(await _userService.GetAsync(id.ToString()));
    }
    
    [HttpPut("profile/{id}")] //ADMIN UPDATE USER
    //Permissions Here
    public async Task<IActionResult> UpdateUserAsync(UpdateProfileRequest request, Guid id)
    {
        return Ok(await _identityService.UpdateProfileAsync(request, id.ToString()));
    }



    private string GenerateOrigin()
    {
        string baseUrl = $"{this.Request.Scheme}://{this.Request.Host.Value}{this.Request.PathBase.Value}";
        string origin = string.IsNullOrEmpty(Request.Headers["origin"].ToString()) ? baseUrl : Request.Headers["origin"].ToString();
        return origin;
    }
}