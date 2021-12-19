using ServerApp.Shared.DTOs.Filters;

namespace ServerApp.Shared.DTOs.Identity;

public class UserListFilter : PaginationFilter
{
    public bool? IsActive { get; set; }
}