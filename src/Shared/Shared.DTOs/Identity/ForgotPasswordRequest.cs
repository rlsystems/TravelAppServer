using System.ComponentModel.DataAnnotations;

namespace ServerApp.Shared.DTOs.Identity;

public class ForgotPasswordRequest
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
}