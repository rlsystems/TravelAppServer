using ServerApp.Shared.DTOs.Storage;

namespace ServerApp.Shared.DTOs.Identity;

public class UpdateProfileRequest : IMustBeValid
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }

    public bool IsActive { get; set; }
    public FileUploadRequest Image { get; set; }
}