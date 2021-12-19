using ServerApp.Application.Common.Interfaces;
using ServerApp.Application.Wrapper;
using ServerApp.Shared.DTOs.Identity;

namespace ServerApp.Application.Abstractions.Services.Identity;

public interface ITokenService : ITransientService
{
    Task<IResult<TokenResponse>> GetTokenAsync(TokenRequest request, string ipAddress);

    Task<IResult<TokenResponse>> RefreshTokenAsync(RefreshTokenRequest request, string ipAddress);
}