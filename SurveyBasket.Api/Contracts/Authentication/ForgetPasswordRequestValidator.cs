using FluentValidation;
using Microsoft.AspNetCore.Identity.Data;

namespace SurveyBasket.API.Contracts.Authentication
{
    public class ForgetPasswordRequestValidator : AbstractValidator<ForgetPasswordRequest>
    {
        public ForgetPasswordRequestValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();
        }
    }
}
