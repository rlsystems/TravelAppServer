using ServerApp.Application.Abstractions.Services.Identity;
using ServerApp.Application.Common.Interfaces;
using ServerApp.Application.Wrapper;
using ServerApp.Domain.Catalog;
using ServerApp.Shared.DTOs;

namespace ServerApp.Application.Dashboard;

public class StatsService : IStatsService
{
    private readonly IUserService _userService;
    private readonly IRoleService _roleService;
    private readonly IRepositoryAsync _repository;

    public StatsService(IRepositoryAsync repository, IRoleService roleService, IUserService userService)
    {
        _repository = repository;
        _roleService = roleService;
        _userService = userService;
    }

    public async Task<IResult<StatsDto>> GetDataAsync()
    {
        var stats = new StatsDto
        {
            ProductCount = await _repository.GetCountAsync<Product>(),
            BrandCount = await _repository.GetCountAsync<Brand>(),
            UserCount = await _userService.GetCountAsync(),
            RoleCount = await _roleService.GetCountAsync()
        };
        return await Result<StatsDto>.SuccessAsync(stats);
    }
}