
using SurveyBasket.API.Contracts.Authentication;
using SurveyBasket.API.Abstractions;
using OneOf;
using Microsoft.AspNetCore.Identity.Data;
using RegisterRequest = SurveyBasket.API.Contracts.Authentication.RegisterRequest;
using ResendConfirmationEmailRequest = SurveyBasket.API.Contracts.Authentication.ResendConfirmationEmailRequest;
using ResetPasswordRequest = SurveyBasket.API.Contracts.Authentication.ResetPasswordRequest;

namespace SurveyBasket.API.Services
{
    public interface IAuthService
    {
        Task<Result<AuthResponse>> GetTokenAsync(string email, string password, CancellationToken cancellationToken = default);
        Task<Result<AuthResponse>> GetRefreshTokenAsync(string token, string refreshToken, CancellationToken cancellationToken = default);
        Task<Result> RevokeRefreshTokenAsync(string token, string refreshToken, CancellationToken cancellationToken = default);
        Task<Result> RegisterAsync(RegisterRequest request, CancellationToken cancellationToken = default);
        Task<Result> ConfirmEmailAsync(ConfirmEmailRequest request);
        Task<Result> ResendConfirmationEmailAsync(ResendConfirmationEmailRequest request);
        Task<Result> SendResetPasswordCodeAsync(string email);
        Task<Result> ResetPasswordAsync(ResetPasswordRequest request);
    }
}
