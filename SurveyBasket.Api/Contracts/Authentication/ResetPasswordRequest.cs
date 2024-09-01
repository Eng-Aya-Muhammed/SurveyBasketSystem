namespace SurveyBasket.API.Contracts.Authentication
{
    public record ResetPasswordRequest(
     string Email,
     string Code,
     string NewPassword
 );
}
