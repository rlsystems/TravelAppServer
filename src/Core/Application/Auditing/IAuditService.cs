using ServerApp.Application.Common.Interfaces;
using ServerApp.Application.Wrapper;
using ServerApp.Shared.DTOs.Auditing;

namespace ServerApp.Application.Auditing;

public interface IAuditService : ITransientService
{
    Task<IResult<IEnumerable<AuditResponse>>> GetUserTrailsAsync(Guid userId);
}