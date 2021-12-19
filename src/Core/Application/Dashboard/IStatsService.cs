using ServerApp.Application.Common.Interfaces;
using ServerApp.Application.Wrapper;
using ServerApp.Shared.DTOs;

namespace ServerApp.Application.Dashboard;

public interface IStatsService : ITransientService
{
    Task<IResult<StatsDto>> GetDataAsync();
}